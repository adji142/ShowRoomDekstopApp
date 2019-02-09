using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.BonSementara
{
    public partial class frmKasbonBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        Int16 nBrow;
        Int32 nRealSisa;
 
        public frmKasbonBrowse()
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(1 - _toDate.Day);
            nBrow = 1;
            rangeTanggal.FromDate = _fromDate;
            rangeTanggal.ToDate = _toDate;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#region Functions
        public void FindRow(string columnName, string value, Int16 gridnum)
        {
            switch (gridnum)
            {
                case 1:
                    {
                        dataGridView1.FindRow(columnName, value);
                        break;
                    }
                case 2:
                    {
                        dataGridViewVju.FindRow(columnName, value);
                        break;
                    }
                case 3:
                    {
                        dataGridViewBkm.FindRow(columnName, value);
                        break;
                    }
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KasBon_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalAwal", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalAkhir", SqlDbType.Date, _toDate));
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

        public void Vju_RefreshData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    Guid headRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_KasBonVJU_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridViewVju.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }
        
        public void Bkm_RefreshData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    Guid headRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_KasBonPenyelesaian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridViewBkm.AutoGenerateColumns = false;
                        dataGridViewBkm.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }
        
#endregion
        
        private void frmKasbonBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rangeTanggal.FromDate;
            _toDate = (DateTime)rangeTanggal.ToDate;
            RefreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (nBrow)
            {
                case 1:
                    {
                        BonSementara.FrmKasbonUpdate ifrmChild = new BonSementara.FrmKasbonUpdate(this);
                        ifrmChild.ShowDialog();
                        break;
                    }
                case 2:
                    {
                        nRealSisa = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["Sisa"].Value);
                        if (nRealSisa != 0)
                        {
                            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            BonSementara.frmKasbonVJU ifrmChild = new BonSementara.frmKasbonVJU(this, rowID);
                            ifrmChild.ShowDialog();
                        }
                        break;
                    }
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            nRealSisa = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["Sisa"].Value);
            if (nRealSisa != 0)
            {
                switch (nBrow)
                {
                    case 1:
                        {
                            if (dataGridView1.SelectedCells.Count > 0)
                            {
                                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                BonSementara.FrmKasbonUpdate ifrmChild = new BonSementara.FrmKasbonUpdate(this, rowID);
                                ifrmChild.ShowDialog();
                            }
                            break;
                        }
                    case 2:
                        {
                            if (dataGridViewVju.SelectedCells.Count > 0)
                            {
                                Guid VjuRowID = (Guid)dataGridViewVju.SelectedCells[0].OwningRow.Cells["VjuRowID"].Value;
                                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                BonSementara.frmKasbonVJU ifrmChild = new BonSementara.frmKasbonVJU(this, rowID, VjuRowID);
                                ifrmChild.ShowDialog();
                            }
                            break;
                        }
                }
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            nBrow = 1;
        }

        private void dataGridViewVju_Enter(object sender, EventArgs e)
        {
            nBrow = 2;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Vju_RefreshData();
            Bkm_RefreshData();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            nRealSisa = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["Sisa"].Value);
            if (nRealSisa != 0)
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                switch (nBrow)
                {
                    case 1:
                        {
                            String cPilih;
                            cPilih = MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.YesNo).ToString();
                            if (cPilih == "Yes")
                            {
                                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                db.Commands.Add(db.CreateCommand("usp_Kasbon_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                                RefreshData();
                            }
                            break;
                        }
                    case 2:
                        {
                            String cPilih;
                            cPilih = MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.YesNo).ToString();
                            if (cPilih == "Yes")
                            {
                                Guid _headRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                Guid _rowID = (Guid)dataGridViewVju.SelectedCells[0].OwningRow.Cells["VjuRowID"].Value;
                                db.Commands.Add(db.CreateCommand("usp_KasbonVJU_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                                Vju_RefreshData();
                                RefreshData();
                                FindRow("RowID", _headRowID.ToString(), 1);
                            }
                            break;
                        }
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            nBrow = 2;
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            nBrow = 2;
        }
    }
}
