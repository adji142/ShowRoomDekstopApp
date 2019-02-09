namespace ISA.Showroom.Finance.GL
{
    partial class frmSubJournalUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubJournalUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.partnerComboBox1 = new Controls.PartnerComboBox();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.numericTextBox1 = new ISA.Controls.NumericTextBox();
            this.commonTextBox2 = new ISA.Controls.CommonTextBox();
            this.numericTextBox2 = new ISA.Controls.NumericTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Part";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nomor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prosen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Uraian";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nominal";
            // 
            // partnerComboBox1
            // 
            this.partnerComboBox1.DisplayMember = "Display";
            this.partnerComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partnerComboBox1.FormattingEnabled = true;
            this.partnerComboBox1.Location = new System.Drawing.Point(110, 25);
            this.partnerComboBox1.Name = "partnerComboBox1";
            this.partnerComboBox1.PartnerID = "";
            this.partnerComboBox1.Size = new System.Drawing.Size(169, 22);
            this.partnerComboBox1.TabIndex = 8;
            this.partnerComboBox1.ValueMember = "KodeTransaksi";
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Location = new System.Drawing.Point(110, 56);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.Size = new System.Drawing.Size(100, 20);
            this.commonTextBox1.TabIndex = 9;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(110, 86);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.ReadOnly = true;
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 10;
            this.numericTextBox1.Text = "0";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // commonTextBox2
            // 
            this.commonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox2.Location = new System.Drawing.Point(110, 115);
            this.commonTextBox2.Name = "commonTextBox2";
            this.commonTextBox2.Size = new System.Drawing.Size(472, 20);
            this.commonTextBox2.TabIndex = 11;
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(110, 146);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.ReadOnly = true;
            this.numericTextBox2.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox2.TabIndex = 12;
            this.numericTextBox2.Text = "0";
            this.numericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(384, 196);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(511, 196);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmSubJournalUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(623, 248);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.commonTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.partnerComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmSubJournalUpdate";
            this.Load += new System.EventHandler(this.frmSubJournalUpdate_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.partnerComboBox1, 0);
            this.Controls.SetChildIndex(this.commonTextBox1, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.Controls.SetChildIndex(this.commonTextBox2, 0);
            this.Controls.SetChildIndex(this.numericTextBox2, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Showroom.Finance.Controls.PartnerComboBox partnerComboBox1;
        private ISA.Controls.CommonTextBox commonTextBox1;
        private ISA.Controls.NumericTextBox numericTextBox1;
        private ISA.Controls.CommonTextBox commonTextBox2;
        private ISA.Controls.NumericTextBox numericTextBox2;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
    }
}
