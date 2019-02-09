using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ISA.Showroom.Penjualan
{
    public partial class frmBABPKB_TLA : ISA.Controls.BaseForm
    {
        public string result;
        Guid _penjRowID;
        bool _saveable = true;
        public frmBABPKB_TLA(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            _penjRowID = PenjRowID;
            this.Caller = Caller;
        }

        private void frmBABPKB_TLA_Load(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Penjualan_BABPKB_GET"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                if (dummy.Rows.Count > 0)
                {
                    String tempnopol = Tools.isNull(dummy.Rows[0]["Nopol"], "N/A").ToString();
                    String tempnobpkb = Tools.isNull(dummy.Rows[0]["NoBPKB"], "N/A").ToString();
                    if (tempnopol == "N/A" && tempnobpkb == "N/A")
                    {
                        txtNoBPKB.Text = "";
                        txtNopol.Text = "";
                        _saveable = true;
                        cmdBABPKB.Enabled = true;
                    }
                    else
                    {
                        txtNoBPKB.Text = tempnobpkb;
                        txtNopol.Text = tempnopol;
                        txtNoBPKB.Enabled = false;
                        txtNoBPKB.ReadOnly = true;
                        txtNopol.Enabled = false;
                        txtNopol.ReadOnly = true;
                        _saveable = false;
                        cmdBABPKB.Enabled = true;
                    }
                }
            }
        }

        private void txtNopol_Leave(object sender, EventArgs e)
        {
            String strpattern = "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$"; //Pattern is Ok
            Regex regex = new Regex(strpattern);
            if (regex.Match(txtNopol.Text).Success)
            {
                // passed
            }
            else
            {
                MessageBox.Show("Input No. Polisi tidak sesuai pola, isikan tanpa spasi");
                txtNopol.Focus();
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            result = "close";
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            result = "save";
            if (_saveable == true)
            {
                SimpanData();
            }
            else
            {
                this.Close();
            }
        }

        private void cmdBABPKB_Click(object sender, EventArgs e)
        {
            result = "print";
            if (_saveable == true)
            {
                SimpanData();
            }
            else
            {
                this.Close();
            }
        }

        private void SimpanData()
        {
            if (string.IsNullOrEmpty(txtNopol.Text))
            {
                MessageBox.Show("Isikan Nomor Polisi terlebih dahulu!");
                txtNopol.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNoBPKB.Text) )
            {
                MessageBox.Show("Isikan Nomor BPKB terlebih dahulu!");
                txtNoBPKB.Focus();
                return;
            }

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_BABPKB_GET"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txtNoBPKB.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diproses!");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Terjadi error!" + ex.Message);
                return;
            }

        }

        private void cmdBABPKB_MouseEnter(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            ToolTip message = new ToolTip();
            message.Show("Simpan data dan Print BABPKB", target, 0, 22, 1500);
        }

        private void cmdSave_MouseEnter(object sender, EventArgs e)
        {
            ISA.Controls.CommandButton target = (ISA.Controls.CommandButton)sender;
            ToolTip message = new ToolTip();
            message.Show("Simpan data saja, tanpa Print BABPKB!", target, 0, 22, 1500);
        }
    }
}
