using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Master
{
    public partial class frmKursBrowse : ISA.Controls.BaseForm
    {
        int _pilihFilter = 0;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public frmKursBrowse()
        {
            InitializeComponent();
            rgdTglKurs.FromDate = GlobalVar.GetServerDate;
            rgdTglKurs.ToDate = GlobalVar.GetServerDate;
//            fillComboMataUang();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKursBrowse_Load(object sender, EventArgs e)
        {
            fcbo.fillComboMataUang(cboMataUang);
            rdoTanggal.Checked = true;
            RefreshData();
        }

        public void RefreshData()
        {
            if (_pilihFilter == 0)
            {
                rgdTglKurs.Visible = true;
                cboMataUang.Visible = false;
            }
            else
            {
                rgdTglKurs.Visible = false;
                cboMataUang.Visible = true;
            }
            rgdTglKurs.Refresh();
            cboMataUang.Refresh();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    if (_pilihFilter == 0)
                    {
                        db.Commands.Add(db.CreateCommand("usp_KursMataUang_LIST_FILTER_Tanggal"));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalAwal", SqlDbType.Date, rgdTglKurs.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalAkhir", SqlDbType.Date, rgdTglKurs.ToDate));
                    } else {
                        db.Commands.Add(db.CreateCommand("usp_KursMataUang_LIST_FILTER_MataUang"));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, Tools.isNull(cboMataUang.SelectedValue,System.Data.SqlTypes.SqlGuid.Null)));
                    }
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

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmKursMataUangUpdate ifrmChild = new Master.frmKursMataUangUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmKursMataUangUpdate ifrmChild = new Master.frmKursMataUangUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show("Hapus Data Kurs ini ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KursMataUang_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
                    }
                    catch (DataException ex)
                    {
                        Error.LogError(ex);
                    }

                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void rdoTanggal_CheckedChanged(object sender, EventArgs e)
        {
            _pilihFilter = 0;
            RefreshData();
        }

        private void rdoMataUang_CheckedChanged(object sender, EventArgs e)
        {
            _pilihFilter = 1;
            RefreshData();
        }

        private void rgdTglKurs_Validating(object sender, CancelEventArgs e)
        {
            RefreshData();
        }

        private void cboMataUang_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
    }

