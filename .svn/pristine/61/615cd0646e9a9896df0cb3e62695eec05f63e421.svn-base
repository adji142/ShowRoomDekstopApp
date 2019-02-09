using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.PiutangKaryawan
{
    public partial class frmPiutangKaryawanBrowseAcc : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;

        public frmPiutangKaryawanBrowseAcc() 
        {
            InitializeComponent();

        }
       
        private void frmPiutangKaryawanBrowseAcc_Load(object sender, EventArgs e)
        {
            
            RefreshData();
            SetupDefaultData(); 
        }

        #region Function 

        public void SetupDefaultData()
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-1 * GlobalVar.GetServerDate.Day).AddDays(1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date; 
        }

        public void RefreshData()
        {
            if ((rangeDateBox1.FromDate!=null) && (rangeDateBox1.ToDate!=null))
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    _fromDate = (DateTime)rangeDateBox1.FromDate;
                    _toDate = (DateTime)rangeDateBox1.ToDate;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST_FILTER_Acc"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, _toDate));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPiutangKaryawan.DataSource = dt;

                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion 

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void cmdAcc_Click(object sender, EventArgs e)
        {
            if (dataGridPiutangKaryawan.SelectedCells.Count > 0)
            {
                Guid _rowID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                PiutangKaryawan.FrmPiutangKaryawanUpdateHeader ifrmChild = new PiutangKaryawan.FrmPiutangKaryawanUpdateHeader(this, _rowID, Guid.Empty);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else MessageBox.Show("Tidak ada data yang dipilih.");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
