using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmMutasiUangBrowse : ISA.Controls.BaseForm 
    { 
        DateTime _fromDate, _toDate; 
         
        public frmMutasiUangBrowse()
        { 
            InitializeComponent();

            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(1 - _toDate.Day);
            rgTglMts.FromDate = _fromDate;
            rgTglMts.ToDate = _toDate;
        }

        private void cmdBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPengeluaranUangAcc_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Keuangan.frmMutasiUangUpdate ifrmChild = new Keuangan.frmMutasiUangUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Keuangan.frmMutasiUangUpdate ifrmChild = new Keuangan.frmMutasiUangUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgTglMts.FromDate;
            _toDate = (DateTime)rgTglMts.ToDate;
            RefreshData();
        }


        #region UserDefinedFunctions
        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_MutasiUang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }


        private void DeleteData()
        {
             if(dataGridView1.Rows.Count >0)
             {
                try
                {
                    DialogResult Result= MessageBox.Show(Messages.Question.AskDelete, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    switch (Result)
                    {
                        case DialogResult.OK:
                            {
                                Guid RowId = (Guid)this.dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_MutasiUang_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowId));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                MessageBox.Show(Messages.Confirm.DeleteSuccess);
                                RefreshData();
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                return;
//                                break;
                            }
                    }


                }
                catch
                {

                }
             }
        }


        #endregion

        #region Parameter Lock


        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
                _parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);

            }
            return _parameterkuncian;
        }

        private bool ValidasiSimpan()
        {
            DateTime Tanggal = (DateTime)this.dataGridView1.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
            bool Expired = false;
            List<int> parameter = ParameterKuncian();
            if (Tanggal <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || Tanggal >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
            { Expired = true; }
            return Expired;
        }


        #endregion


        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (ValidasiSimpan() == true)
            {
                MessageBox.Show("Maaf, proses delete sudah tidak bisa dilakukan," + Environment.NewLine + "karena sudah di luar dari batas waktu yang ditentukan.");
                return;
            }
            else
            {
                DeleteData();
            }
        }

    }

}