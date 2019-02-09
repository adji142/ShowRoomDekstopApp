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
    public partial class frmKotaBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridProvinsi, GridKota, GridKecamatan, GridKelurahan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridProvinsi;

        DataTable dtProv, dtKota, dtKec, dtKel;

        public frmKotaBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void frmKotaBrowse_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SecurityManager.IsManager())
                {
                    cmdAdd.Enabled = false;
                    cmdEdit.Enabled = false;
                    cmdDelete.Enabled = false;
                }
                this.Cursor = Cursors.WaitCursor;
                dtProv = FillComboBox.DBGetProvinsi(Guid.Empty);

                if (dtProv.Rows.Count > 0)
                {
                    dtProv.DefaultView.Sort = "Nama";
                    gridProvinsi.DataSource = dtProv.DefaultView;
                    LoadKota();
                }
                else
                {
                    dtKota.Clear();
                    gridKota.DataSource = dtKota.DefaultView;
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

        private void LoadKota()
        {
            try
            {
                Guid RowIDProv = (Guid)gridProvinsi.SelectedCells[0].OwningRow.Cells["ProvRowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                dtKota = FillComboBox.DBGetKota(Guid.Empty, RowIDProv);

                if (dtKota.Rows.Count > 0)
                {
                    dtKota.DefaultView.Sort = "Nama";
                    gridKota.AutoGenerateColumns = false;
                    gridKota.DataSource = dtKota.DefaultView;
                    LoadKec();
                }
                else
                {
                    dtKota.Clear();
                    gridKota.DataSource = dtKota.DefaultView;
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

        private void LoadKec()
        {
            try
            {
                Guid RowIDKota = (Guid)gridKota.SelectedCells[0].OwningRow.Cells["KotaRowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                dtKec = FillComboBox.DBGetKecamatan(Guid.Empty, RowIDKota);

                if (dtKec.Rows.Count > 0)
                {
                    dtKec.DefaultView.Sort = "Nama";
                    gridKecamatan.AutoGenerateColumns = false;
                    gridKecamatan.DataSource = dtKec.DefaultView;
                    LoadKel();
                }
                else
                {
                    dtKec.Clear();
                    gridKecamatan.DataSource = dtKec.DefaultView;
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

        private void LoadKel()
        {
            try
            {
                Guid RowIDKec = (Guid)gridKecamatan.SelectedCells[0].OwningRow.Cells["KecRowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                dtKel = FillComboBox.DBGetKelurahan(Guid.Empty, RowIDKec);
                    
                if (dtKel.Rows.Count > 0)
                {
                    dtKel.DefaultView.Sort = "Nama";
                    gridKelurahan.AutoGenerateColumns = false;
                    gridKelurahan.DataSource = dtKel.DefaultView;
                }
                else
                {
                    dtKel.Clear();
                    gridKelurahan.DataSource = dtKel.DefaultView;
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
                case enumSelectedGrid.GridProvinsi :
                    Master.frmKotaUpdate ifrmChild = new Master.frmKotaUpdate(this, "Provinsi", null, Guid.Empty);
                    ifrmChild.ShowDialog();
                    break;
                case enumSelectedGrid.GridKota :
                    Guid _provRowID = (Guid)gridProvinsi.SelectedCells[0].OwningRow.Cells["ProvRowID"].Value;
                    String _provinsi = gridProvinsi.SelectedCells[0].OwningRow.Cells["Provinsi"].Value.ToString();
                    Master.frmKotaUpdate ifrmChild2 = new Master.frmKotaUpdate(this, "Kota", _provinsi, _provRowID);
                    ifrmChild2.ShowDialog();
                    break;
                case enumSelectedGrid.GridKecamatan :
                    if (gridKota.RowCount > 0)
                    {
                        Guid _kotaRowID = (Guid)gridKota.SelectedCells[0].OwningRow.Cells["KotaRowID"].Value;
                        String _kota = gridKota.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                        Master.frmKotaUpdate ifrmChild3 = new Master.frmKotaUpdate(this, "Kecamatan", _kota, _kotaRowID);
                        ifrmChild3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Data Kota masih kosong");
                    }
                    break;
                case enumSelectedGrid.GridKelurahan :
                    if (gridKecamatan.RowCount > 0)
                    {
                        Guid _kecRowID = (Guid)gridKecamatan.SelectedCells[0].OwningRow.Cells["KecRowID"].Value;
                        String _kecamatan = gridKecamatan.SelectedCells[0].OwningRow.Cells["Kecamatan"].Value.ToString();
                        Master.frmKotaUpdate ifrmChild4 = new Master.frmKotaUpdate(this, "Kelurahan", _kecamatan, _kecRowID);
                        ifrmChild4.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Data Kecamatan masih kosong");
                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.GridProvinsi :
                    if (gridProvinsi.RowCount > 0)
                    {
                        Guid rowID = (Guid)gridProvinsi.SelectedCells[0].OwningRow.Cells["ProvRowID"].Value;
                        Master.frmKotaUpdate ifrmChild = new Master.frmKotaUpdate(this, "Provinsi", rowID);
                        ifrmChild.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.GridKota :
                    if (gridKota.RowCount > 0)
                    {
                        Guid rowID2 = (Guid)gridKota.SelectedCells[0].OwningRow.Cells["KotaRowID"].Value;
                        Master.frmKotaUpdate ifrmChild2 = new Master.frmKotaUpdate(this, "Kota", rowID2);
                        ifrmChild2.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.GridKecamatan :
                    if (gridKecamatan.RowCount > 0)
                    {
                        Guid rowID3 = (Guid)gridKecamatan.SelectedCells[0].OwningRow.Cells["KecRowID"].Value;
                        Master.frmKotaUpdate ifrmChild3 = new Master.frmKotaUpdate(this, "Kecamatan", rowID3);
                        ifrmChild3.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.GridKelurahan :
                    if (gridKelurahan.RowCount > 0)
                    {
                        Guid rowID4 = (Guid)gridKelurahan.SelectedCells[0].OwningRow.Cells["KelRowID"].Value;
                        Master.frmKotaUpdate ifrmChild4 = new Master.frmKotaUpdate(this, "Kelurahan", rowID4);
                        ifrmChild4.ShowDialog();
                    }
                    break;
            }
        }

        public void RefreshRowData(string Sts, Guid _rowID)
        {
            DataTable dtRefresh;
            using (Database db = new Database())
            {
                switch (Sts)
                {
                    case "Prov":
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        break;
                    case "Kota":
                        db.Commands.Add(db.CreateCommand("usp_Kota_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        break;
                    case "Kec":
                        db.Commands.Add(db.CreateCommand("usp_Kecamatan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        break;
                    case "Kel":
                        db.Commands.Add(db.CreateCommand("usp_Kelurahan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        break;
                }
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                switch (Sts)
                {
                    case "Prov":
                        gridProvinsi.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                        break;
                    case "Kota":
                        gridKota.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                        break;
                    case "Kec":
                        gridKecamatan.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                        break;
                    case "Kel":
                        gridKelurahan.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                        break;
                }
            }
        }

        public void FindRow(string columnName, string value)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.GridProvinsi :
                    gridProvinsi.FindRow(columnName, value);
                    break;
                case enumSelectedGrid.GridKota :
                    gridKota.FindRow(columnName, value);
                    break;
                case enumSelectedGrid.GridKecamatan :
                    gridKecamatan.FindRow(columnName, value);
                    break;
                case enumSelectedGrid.GridKelurahan :
                    gridKelurahan.FindRow(columnName, value);
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
                case enumSelectedGrid.GridProvinsi :
                    if (gridProvinsi.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridProvinsi.SelectedCells[0].OwningRow.Cells["ProvRowID"].Value;

                            DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data");
                                return;
                            }
                            else
                            {   // Pake cekDelete punya Pak Novi
                                if (Class.PenerimaanUang.checkDelete(rowID, "Provinsi") == true) // this.ceckDelete(rowID) == true -> ke Provinsi
                                {
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Provinsi_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                gridProvinsi.Rows.Remove(gridProvinsi.SelectedCells[0].OwningRow);
                                MessageBox.Show("Data berhasil dihapus");
                            }
                        }
                    }
                    break;
                case enumSelectedGrid.GridKota :
                    if (gridKota.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridKota.SelectedCells[0].OwningRow.Cells["KotaRowID"].Value;

                            DataTable dt = FillComboBox.DBGetKecamatan(Guid.Empty, rowID);

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data");
                                return;
                            }
                            else
                            {   // Pake cekDelete punya Pak Novi
                                if (Class.PenerimaanUang.checkDelete(rowID, "Kota") == true) // this.ceckDelete(rowID) == true -> ke Kota 
                                {
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Kota_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                gridKota.Rows.Remove(gridKota.SelectedCells[0].OwningRow);
                                MessageBox.Show("Data berhasil dihapus");
                            }
                        }
                    }
                    break;
                case enumSelectedGrid.GridKecamatan :
                    if (gridKecamatan.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridKecamatan.SelectedCells[0].OwningRow.Cells["KecRowID"].Value;

                            DataTable dt = FillComboBox.DBGetKelurahan(Guid.Empty, rowID);
                            DataTable dtWil = FillComboBox.DBGetWilayah(Guid.Empty, Guid.Empty, rowID);

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data");
                                return;
                            }
                            else if (dtWil.Rows.Count > 0)
                            {
                                MessageBox.Show("Terdapat keterkaitan data");
                                return;
                            }
                            else
                            {   // Pake cekDelete punya Pak Novi
                                if (Class.PenerimaanUang.checkDelete(rowID, "Kecamatan") == true) // this.ceckDelete(rowID) == true -> ke Kecamatan
                                {
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Kecamatan_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                gridKecamatan.Rows.Remove(gridKecamatan.SelectedCells[0].OwningRow);
                                MessageBox.Show("Data berhasil dihapus");
                            }
                        }
                    }
                    break;
                case enumSelectedGrid.GridKelurahan :
                    if (gridKelurahan.RowCount > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)gridKelurahan.SelectedCells[0].OwningRow.Cells["KelRowID"].Value;
                            // Pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Kelurahan") == true)  // this.ceckDelete(rowID) == true -> ke Kelurahan
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {   
                                db.Commands.Add(db.CreateCommand("usp_Kelurahan_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            gridKelurahan.Rows.Remove(gridKelurahan.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");
                        }
                    }
                    break;
            }
        }

        private void gridProvinsi_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProvinsi.SelectedCells.Count > 0)
            {
                LoadKota();
                if (gridKota.RowCount > 0)
                {
                    LoadKec();
                    if (gridKecamatan.RowCount > 0)
                    {
                        LoadKel();
                    }
                    else
                    {
                        dtKel = new DataTable();
                        dtKel.Clear();
                        gridKelurahan.DataSource = dtKel.DefaultView;
                    }
                }
                else
                {
                    dtKec = new DataTable();
                    dtKec.Clear();
                    gridKecamatan.DataSource = dtKec.DefaultView;
                }
            }
            else
            {
                dtKota = new DataTable();
                dtKota.Clear();
                gridKota.DataSource = dtKota.DefaultView;
            }
        }

        private void gridKota_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKota.SelectedCells.Count > 0)
            {
                LoadKec();
                if (gridKecamatan.RowCount > 0)
                {
                    LoadKel();
                }
                else
                {
                    dtKel = new DataTable();
                    dtKel.Clear();
                    gridKelurahan.DataSource = dtKel.DefaultView;
                }
            }
            else
            {
                dtKec = new DataTable();
                dtKec.Clear();
                gridKecamatan.DataSource = dtKec.DefaultView;
            }
        }

        private void gridKecamatan_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKecamatan.SelectedCells.Count > 0)
            {
                LoadKel();
            }
            else
            {
                dtKel = new DataTable();
                dtKel.Clear();
                gridKelurahan.DataSource = dtKel.DefaultView;
            }
        }

        private void gridProvinsi_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridProvinsi ;
            gridProvinsi_SelectionChanged(sender, e);
        }

        private void gridKota_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridKota;
            gridKota_SelectionChanged(sender, e);
        }

        private void gridKecamatan_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridKecamatan;
            gridKecamatan_SelectionChanged(sender, e);
        }

        private void gridKelurahan_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridKelurahan;
        }
        /*
        private void gridProvinsi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridProvinsi.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridProvinsi.Rows)
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

        private void gridKota_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridKota.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridKota.Rows)
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

        private void gridKecamatan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridKecamatan.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridKecamatan.Rows)
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

        private void gridKelurahan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridKelurahan.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gridKelurahan.Rows)
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
                case enumSelectedGrid.GridProvinsi:
                    cmd = new Command(new Database(), CommandType.Text,
                                                " SELECT *                                                        " +
                                                "   FROM dbo.Provinsi                                             " +
                                                "  WHERE RowID = @RowID                                           " +
                                                "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                             );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
                case enumSelectedGrid.GridKota :
                    cmd = new Command(new Database(), CommandType.Text,
                                                " SELECT *                                                        " +
                                                "   FROM dbo.Kota                                                 " +
                                                "  WHERE RowID = @RowID                                           " +
                                                "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                             );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
                case enumSelectedGrid.GridKecamatan :
                    cmd = new Command(new Database(), CommandType.Text,
                                                " SELECT *                                                        " +
                                                "   FROM dbo.Kecamatan                                            " +
                                                "  WHERE RowID = @RowID                                           " +
                                                "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                             );
                    cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    dt = cmd.ExecuteDataTable();
                    break;
                case enumSelectedGrid.GridKelurahan :
                    cmd = new Command(new Database(), CommandType.Text,
                                                " SELECT *                                                        " +
                                                "   FROM dbo.Kelurahan                                            " +
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
