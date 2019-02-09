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
using System.Globalization;

namespace ISA.Showroom.Master
{
    public partial class frmTargetKolektorBrowse : ISA.Controls.BaseForm
    {
        public frmTargetKolektorBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmTargetKolektorUpdate ifrmChild = new Master.frmTargetKolektorUpdate(this);
            ifrmChild.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmTargetKolektorUpdate ifrmChild = new Master.frmTargetKolektorUpdate(this, rowID);
                ifrmChild.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {   // pake cekDelete punya Pak Novi
                        if (Class.PenerimaanUang.checkDelete(rowID, "TargetKolektor") == true) // this.ceckDelete(rowID) == true -> ke TargetKolektor
                        {
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                            if (GlobalVar.pinResult == false) { return; }
                        }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetKolektor_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        dataGridView1.Rows.Remove(dataGridView1.SelectedCells[0].OwningRow);
                        MessageBox.Show("Data berhasil dihapus");
                    }
                    catch (Exception ex)
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

        public void RefreshBln()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TargetKolektor_LISTPeriode"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    GVBln.DataSource = dt;
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

        public void RefreshData()
        {
            if (GVBln.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DateTime TglAwal= (DateTime)GVBln.SelectedCells[0].OwningRow.Cells["Periode"].Value;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TargetKolektor_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.DateTime, TglAwal));
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
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void frmTargetKolektorBrowse_Load(object sender, EventArgs e)
        {
            RefreshBln();
            RefreshData();
        }

        public void FindRowBln(String ColumnName, String value)
        {
            GVBln.FindRow(ColumnName, value);
        }

        public void FindRow(String ColumnName, String value)
        {
            dataGridView1.FindRow(ColumnName, value);
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
        /*
        private bool ceckDelete(Guid rowID)
        {
            bool hapus = false;
            DataTable dt = new DataTable();

            Command cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.TargetKolektor                                       " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
            cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
            dt = cmd.ExecuteDataTable();

            if (dt.Rows.Count > 0) hapus = false;
            else hapus = true;

            return hapus;
        }
        */ 
    }
}
