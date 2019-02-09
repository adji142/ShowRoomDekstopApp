using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class BaseFormBrowse : ISA.Controls.BaseForm
    {
        public BaseFormBrowse()
        {
            InitializeComponent();
        }


        private void BaseFormBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteData();
            }
        }

        public void RefreshData() { }

        private void deleteData() { }

        private void closeForm() { }
    }
}
