using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmSubJournalDetailUpdate : ISA.Controls.BaseForm
    {
        Guid _subJournalID;
        public frmSubJournalDetailUpdate(Guid subJournalID)
        {
            InitializeComponent();
            _subJournalID = subJournalID;
        }

        private void frmSubJournalDetailUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
