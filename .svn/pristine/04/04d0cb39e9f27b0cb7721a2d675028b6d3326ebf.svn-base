using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;

namespace ISA.Showroom.Master
{
    public partial class frmSurveyorBrowse : ISA.Controls.BaseForm
    {
        public frmSurveyorBrowse()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Surveyor_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("conIdentitas", Type.GetType("System.String"), "AlamatIdt + ' RT/RW ' + RTIdt + '/' + RWIdt + ' Kel. ' + KelurahanIdt + ' Kec. ' + KecamatanIdt + ' ' + KotaIdt + ' ' + ProvinsiIdt");
                    dt.Columns.Add(cConcatenated1);
                    DataColumn cConcatenated2 = new DataColumn("conDomisili", Type.GetType("System.String"), "AlamatDom + ' RT/RW ' + RTDom + '/' + RWDom + ' Kel. ' + KelurahanDom + ' Kec. ' + KecamatanDom + ' ' + KotaDom + ' ' + ProvinsiDom");
                    dt.Columns.Add(cConcatenated2);
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

        private void frmSurveyorBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void FindRow(String ColumnName, String value)
        {
            dataGridView1.FindRow(ColumnName, value);
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (dataGridView1.SelectedCells.Count > 0)
            {
                string namacustomer = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable dtKol = FillComboBox.DBGetTargetSurveyor(Guid.Empty, rowID);
                        if (dtKol.Rows.Count > 0)
                        {
                            MessageBox.Show("Terdapat keterkaitan data !");
                            return;
                        }
                        else        
                        {   // pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Surveyor") == true) // this.ceckDelete(rowID) == true -> ke Surveyor
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Surveyor_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                            dataGridView1.Rows.Remove(dataGridView1.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");
                        }   
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmSurveyorUpdate ifrmChild = new Master.frmSurveyorUpdate(this, rowID);
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmSurveyorUpdate ifrmChild = new Master.frmSurveyorUpdate(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
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
                                        "   FROM dbo.Surveyor                                             " +
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
