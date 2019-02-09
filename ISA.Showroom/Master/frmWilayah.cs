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
    public partial class frmWilayah : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridArea, GridWilayah, GridKolektor };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridArea;

        DataTable dtArea, dtWilayah, dtKolektor, dtRefresh;

        public frmWilayah()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWilayah_Load(object sender, EventArgs e)
        {
            try
            {
                LoadArea();
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


        private void LoadArea()
        {
            this.Cursor = Cursors.WaitCursor;
            dtArea = FillComboBox.DBGetArea(Guid.Empty);
            if (dtArea.Rows.Count > 0)
            {
                dtArea.DefaultView.Sort = "Area";
                gridArea.DataSource = dtArea.DefaultView;
                this.LoadWilayah();
                this.LoadKolektor();
            }
            else
            {
                dtWilayah = new DataTable();
                dtWilayah.Clear();
                gridWilayah.DataSource = dtArea.DefaultView;
                dtKolektor = new DataTable();
                dtKolektor.Clear();
                gridKolektor.DataSource = dtKolektor.DefaultView;
            }
        }

        private void LoadWilayah()
        {
            try
            {
                if (gridArea.SelectedCells.Count > 0)
                {
                    Guid RowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    dtWilayah = FillComboBox.DBGetWilayah(Guid.Empty, RowID, Guid.Empty);
                    DataColumn cConcatenated = new DataColumn("conWilayah", Type.GetType("System.String"), "'Kec. ' + Kecamatan + ', ' + Kota + ', ' + Provinsi");
                    dtWilayah.Columns.Add(cConcatenated);

                    if (dtWilayah.Rows.Count > 0)
                    {
                        gridKolektor.AutoGenerateColumns = false;
                        dtWilayah.DefaultView.Sort = "Kecamatan";
                        gridWilayah.DataSource = dtWilayah.DefaultView;
                    }
                    else
                    {
                        dtWilayah.Clear();
                        gridWilayah.DataSource = dtWilayah.DefaultView;
                    }
                }
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

        private void LoadKolektor()
        {
            try
            {
                if (gridArea.SelectedCells.Count > 0)
                {
                    Guid RowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    dtKolektor = FillComboBox.DBGetAreaKolektor(Guid.Empty, RowID, Guid.Empty);

                    if (dtKolektor.Rows.Count > 0)
                    {
                        gridKolektor.AutoGenerateColumns = false;
                        dtKolektor.DefaultView.Sort = "Kolektor";
                        gridKolektor.DataSource = dtKolektor.DefaultView;
                    }
                    else
                    {
                        dtKolektor.Clear();
                        gridKolektor.DataSource = dtKolektor.DefaultView;
                    }
                }
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.GridArea :
                    Master.frmWilayahUpdate ifrmChild = new Master.frmWilayahUpdate(this, "Area", null, Guid.Empty, "New");
                    ifrmChild.ShowDialog();
                    break;
                case enumSelectedGrid.GridWilayah :
                    Guid _areaRowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    String _area = gridArea.SelectedCells[0].OwningRow.Cells["Area"].Value.ToString();
                    Master.frmWilayahUpdate ifrmChild2 = new Master.frmWilayahUpdate(this, "Wilayah", _area, _areaRowID, "New");
                    ifrmChild2.ShowDialog();                    
                    break;
                case enumSelectedGrid.GridKolektor :
                    Guid _rowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    String _nama = gridArea.SelectedCells[0].OwningRow.Cells["Area"].Value.ToString();
                    Master.frmWilayahUpdate ifrmChild3 = new Master.frmWilayahUpdate(this, "Kolektor", _nama, _rowID, "New");
                    ifrmChild3.ShowDialog();
                    break;
            }
            LoadArea();
            this.LoadKolektor();
            this.LoadWilayah();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.GridArea:
                    if (gridArea.RowCount > 0)
                    {
                        Guid rowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Master.frmWilayahUpdate ifrmChild = new Master.frmWilayahUpdate(this, "Area", null, rowID, "Update");
                        ifrmChild.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.GridWilayah:
                    if (gridWilayah.RowCount > 0)
                    {
                        Guid rowID2 = (Guid)gridWilayah.SelectedCells[0].OwningRow.Cells["WilRowID"].Value;
                        String area2 = gridArea.SelectedCells[0].OwningRow.Cells["Area"].Value.ToString();
                        Master.frmWilayahUpdate ifrmChild2 = new Master.frmWilayahUpdate(this, "Wilayah", area2, rowID2, "Update");
                        ifrmChild2.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.GridKolektor:
                    if (gridKolektor.RowCount > 0)
                    {
                        Guid rowID3 = (Guid)gridKolektor.SelectedCells[0].OwningRow.Cells["KolRowID"].Value;
                        String area3 = gridArea.SelectedCells[0].OwningRow.Cells["Area"].Value.ToString();
                        Master.frmWilayahUpdate ifrmChild3 = new Master.frmWilayahUpdate(this, "Kolektor", area3, rowID3, "Update");
                        ifrmChild3.ShowDialog();
                    }
                    break;
            }
            LoadArea();
            this.LoadKolektor();
            this.LoadWilayah();
        }

        public void RefreshRowData(string Sts, Guid _areaRowID, Guid _rowid)
        {
            using (Database db = new Database())
            {
                switch (Sts)
                {
                    case "Area":
                        dtRefresh = FillComboBox.DBGetArea(Guid.Empty);
                        break;
                    case "Wilayah":
                        dtRefresh = FillComboBox.DBGetWilayah(Guid.Empty, _areaRowID, Guid.Empty);
                        break;
                    case "Kolektor":
                        dtRefresh = FillComboBox.DBGetAreaKolektor(Guid.Empty, _areaRowID, Guid.Empty);
                        break;
                }
            }
            if (dtRefresh.Rows.Count > 0)
            {
                switch (Sts)
                {
                    case "Area":
                        gridArea.FindRow("RowID", _rowid.ToString());
                        break;
                    case "Wilayah":
                        gridWilayah.FindRow("WilRowID", _rowid.ToString());
                        break;
                    case "Kolektor":
                        gridKolektor.FindRow("KolRowID", _rowid.ToString());
                        break;
                }
            }
        }

        public void FindRow(string columnName, string value)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.GridArea :
                    gridArea.FindRow(columnName, value);
                    break;
                case enumSelectedGrid.GridWilayah :
                    gridWilayah.FindRow(columnName, value);
                    break;
                case enumSelectedGrid.GridKolektor :
                    gridKolektor.FindRow(columnName, value);
                    break;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            switch (selectedGrid)
            {
                case enumSelectedGrid.GridArea :
                    if (gridArea.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridArea.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                            DataTable dtW = FillComboBox.DBGetWilayah(Guid.Empty, rowID, Guid.Empty);
                            DataTable dtK = FillComboBox.DBGetAreaKolektor(Guid.Empty, rowID, Guid.Empty);
                            if (dtW.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data !");
                            }
                            else if (dtK.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data !");
                            }
                            else
                            {   // pake cek delete punya Pak Novi
                                if (Class.PenerimaanUang.checkDelete(rowID, "Area") == true) // this.ceckDelete(rowID) == true -> ke Area 
                                {
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Area_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                gridArea.Rows.Remove(gridArea.SelectedCells[0].OwningRow);
                                MessageBox.Show("Data berhasil dihapus");
                            }
                        }
                    }
                    break;
                case enumSelectedGrid.GridWilayah :
                    if (gridWilayah.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridWilayah.SelectedCells[0].OwningRow.Cells["WilRowID"].Value;
                            // pake cek delete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Wilayah") == true) // this.ceckDelete(rowID) == true -> ke Wilayah 
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_Wilayah_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            gridWilayah.Rows.Remove(gridWilayah.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");                            
                        }
                    }
                    break;
                case enumSelectedGrid.GridKolektor :
                    if (gridKolektor.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridKolektor.SelectedCells[0].OwningRow.Cells["KolRowID"].Value;
                            // pake cek delete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "AreaKolektor") == true) // this.ceckDelete(rowID) == true -> ke AreaKolektor 
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_Area_Kolektor_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            gridKolektor.Rows.Remove(gridKolektor.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");                            
                        }
                    }
                    break;
            }
        }

        private void gridArea_SelectionChanged(object sender, EventArgs e)
        {
            if (gridArea.SelectedCells.Count > 0)
            {
                this.LoadKolektor();
                this.LoadWilayah();
            }
            else
            {
                dtWilayah = new DataTable();
                dtWilayah.Clear();
                gridWilayah.DataSource = dtWilayah.DefaultView;
                dtKolektor = new DataTable();
                dtKolektor.Clear();
                gridKolektor.DataSource = dtKolektor.DefaultView;
            }
        }

        private void gridArea_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridArea;
            gridArea_SelectionChanged(sender, e);
        }

        private void gridKolektor_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridKolektor;
        }

        private void gridWilayah_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridWilayah;
        }
        /*
        private void gridArea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridArea.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridArea.Rows)
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

        private void gridWilayah_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridWilayah.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridWilayah.Rows)
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

        private void gridKolektor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridKolektor.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridKolektor.Rows)
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
            Command cmd;

            switch (selectedGrid)
            {
                case enumSelectedGrid.GridArea:

                    cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.Area                                                 " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
                case enumSelectedGrid.GridWilayah:
                    cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.Wilayah                                              " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
                case enumSelectedGrid.GridKolektor:
                    cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.AreaKolektor                                         " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
            }

            if (dt.Rows.Count > 0) hapus = false;
            else hapus = true;

            return hapus;
        }
        */ 
    }
}
