using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Showroom.Administrasi
{
    public partial class frmSecurityPartsRolesBrowse : BaseForm
    {
        string _partID;
        DataTable dt = new DataTable();

        public frmSecurityPartsRolesBrowse(string partID)
        {
            InitializeComponent();
            _partID = partID;
            this.txtPart.Text = partID;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSecurityPartsRolesBrowse_Load(object sender, EventArgs e)
        {
            lookupSecurityRoles1.ApplicationID = GlobalVar.ApplicationID;
            dataGridView1.AutoGenerateColumns = false;
            lookupSecurityRoles1.Clear();
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityPartsRoles_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@partID", SqlDbType.VarChar, _partID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "cmdDelete")
            {
                DataGridViewRow curRow = dataGridView1.Rows[e.RowIndex];
                int rowID = int.Parse(curRow.Cells["RowID"].Value.ToString());

                if (MessageBox.Show(Messages.Question.AskDelete, "Delete Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBShowroom))
                        {
                            db.Commands.Add(db.CreateCommand("usp_SecurityPartsRoles_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.Int, rowID));
                            db.Commands[0].ExecuteNonQuery();
                            dataGridView1.Rows.Remove(curRow);
                            MessageBox.Show(Messages.Confirm.DeleteSuccess, "Delete Role");
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBShowroom))
                    {
                        db.Commands.Add(db.CreateCommand("usp_SecurityPartsRoles_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@partID", SqlDbType.VarChar, _partID));
                        db.Commands[0].Parameters.Add(new Parameter("@roleID", SqlDbType.VarChar, lookupSecurityRoles1.RoleID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        MessageBox.Show(Messages.Confirm.UpdateSuccess, "Add Role");
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                RefreshData();
            }
        }

        private bool isValid()
        {
            bool valid = true;
            if (lookupSecurityRoles1.RoleID == "")
            {
                valid = false;
            }
            return valid;
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
        /*
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell iCell in iRow.Cells)
                    {
                        if (iRow.Index % 2 == 0)
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 128);
                        }
                        else
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 255);
                        }
                    }
                }
            }
        }
        */
    }
}
