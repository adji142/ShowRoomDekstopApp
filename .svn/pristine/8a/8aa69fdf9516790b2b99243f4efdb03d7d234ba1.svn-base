using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Pin
{   
    public partial class frmPin : Form
    {
        string pin;
         public frmPin()
        {
            InitializeComponent();
        }

        public void commandButton1_Click(object sender, EventArgs e)
        {

            string kodeCabang = comboBox1.SelectedItem.ToString();

            if (txtKey.Text.ToString().Substring(0, 2) != kodeCabang)
            {
                MessageBox.Show("Pin yang anda masukan salah");
                return;
            }

            pin = key.proses(txtKey.Text, Convert.ToInt32(txtId.Text), kodeCabang);
            txtPin.Text = pin;
            try {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, txtKey.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, txtPin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, Convert.ToInt32(txtId.Text.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKet.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void frmPin_Load(object sender, EventArgs e)
        {
            txtKey.Focus();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtKet.Text = "";
            txtPin.Text = "";
        }
    }
}
