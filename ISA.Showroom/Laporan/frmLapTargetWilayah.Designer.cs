namespace ISA.Showroom.Laporan
{
    partial class frmLapTargetWilayah
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
            this.cmdPRINT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rngTglJual = new ISA.Controls.RangeDateBox();
            this.cbxCabang = new ISA.Controls.CabangComboBox();
            this.SuspendLayout();
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPRINT.Image = global::ISA.Showroom.Properties.Resources.Printer32;
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(249, 230);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(92, 43);
            this.cmdPRINT.TabIndex = 5;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal Jual";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cabang";
            // 
            // rngTglJual
            // 
            this.rngTglJual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rngTglJual.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rngTglJual.FromDate = null;
            this.rngTglJual.Location = new System.Drawing.Point(215, 96);
            this.rngTglJual.Name = "rngTglJual";
            this.rngTglJual.Size = new System.Drawing.Size(257, 22);
            this.rngTglJual.TabIndex = 8;
            this.rngTglJual.ToDate = null;
            // 
            // cbxCabang
            // 
            this.cbxCabang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCabang.CabangID = "";
            this.cbxCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCabang.Font = new System.Drawing.Font("Arial", 8F);
            this.cbxCabang.FormattingEnabled = true;
            this.cbxCabang.Location = new System.Drawing.Point(215, 138);
            this.cbxCabang.Name = "cbxCabang";
            this.cbxCabang.Size = new System.Drawing.Size(180, 22);
            this.cbxCabang.TabIndex = 9;
            // 
            // frmLapTargetWilayah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 321);
            this.Controls.Add(this.cbxCabang);
            this.Controls.Add(this.rngTglJual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdPRINT);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapTargetWilayah";
            this.Text = "Target Wilayah";
            this.Title = "Target Wilayah";
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rngTglJual, 0);
            this.Controls.SetChildIndex(this.cbxCabang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPRINT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.RangeDateBox rngTglJual;
        private ISA.Controls.CabangComboBox cbxCabang;
    }
}