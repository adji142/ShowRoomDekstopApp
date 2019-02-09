using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmJournalDetailUpdate : ISA.Controls.BaseForm
    {
        Guid _HeaderID;

        public string NoPerkiraan
        {
            get { return lookupPerkiraan1.NoPerkiraan; }
            set { lookupPerkiraan1.NoPerkiraan = value; }
        }

        public string NamaPerkiraan
        {
            get { return lookupPerkiraan1.NamaPerkiraan; }
            set { lookupPerkiraan1.NamaPerkiraan = value; }
        }
        public string Uraian
        {
            get { return txtUraian.Text ; }
            set { txtUraian.Text = value; }
        }
        public string DK
        {
            get 
            {
                string _DK = "D";
                if (Kredit > 0)
                    _DK = "K";
                return _DK;
            }            
        }
        public double Debet
        {
            get 
            {
                return txtDebet.GetDoubleValue;
            }
            set 
            {
                txtDebet.Text = value.ToString("#,##0"); 
            }
        }
        public double Kredit
        {
            get
            {
                return txtKredit.GetDoubleValue;
            }
            set
            {
                txtKredit.Text = value.ToString("#,##0");
            }
        }


        public frmJournalDetailUpdate(Guid HeaderID, Form Caller)
        {
            InitializeComponent();
            _HeaderID = HeaderID;
            customGridView1.AutoGenerateColumns = false;
            frmJournalUpdate ju = (frmJournalUpdate)Caller;
            DataView dr = (DataView)ju.customGridView1.DataSource;
            customGridView1.DataSource = dr; 
            
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void lookupPerkiraan1_Load(object sender, EventArgs e)
        {

        }
    }
}
