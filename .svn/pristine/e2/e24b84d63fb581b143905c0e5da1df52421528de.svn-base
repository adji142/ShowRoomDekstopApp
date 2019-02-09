using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom;
using ISA.DAL;
using System.Net;

namespace ISA.Showroom
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (txtUserName.Text.Trim().Length > 0)
            {
                bool isAuthenticate = SecurityManager.IsAuthenticate(txtUserName.Text, SecurityManager.EncodePassword(txtPassword.Text), "ISAShowroomDb");

                if (isAuthenticate)
                {
                    SecurityManager.RecordLoginHistory();

                    this.DialogResult = DialogResult.OK;

                    if (SecurityManager.IsLogin == true)
                    {
                        this.Visible = true;
                        MessageBox.Show(SecurityManager.GetUserLogin(txtUserName.Text.Trim()), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.Enabled = true;

                        return;
                    }
                    this.Visible = false;
                    frmMain ifrmMain = new frmMain();
                    Program.MainForm = ifrmMain;
                    ifrmMain.Show();
                }
                else
                {
                    if (SecurityManager.IsExist(txtUserName.Text))
                    {
                        SecurityManager.RecordLoginAttempt(txtUserName.Text);
                    }
                    MessageBox.Show(Messages.Confirm.LoginFailed);
                }
            }
            this.Enabled = true;
        }

        public void AskLogin()
        {
            txtPassword.Text = "";
            this.Visible = true;
            txtPassword.Focus();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                }
            }

            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.S)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();

                    using (Database db = new Database(GlobalVar.DBShowroom))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_LoginUser_Delete]"));
                        db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, txtUserName.Text.Trim()));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Reset");
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;

                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblHost.Text = Database.Host;

            if (txtUserName.Text == "")
            {
                txtUserName.Focus();   
            }
            else
            {
                txtPassword.Focus();  
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdLogin.PerformClick();
            }
        }

   
    }
}
