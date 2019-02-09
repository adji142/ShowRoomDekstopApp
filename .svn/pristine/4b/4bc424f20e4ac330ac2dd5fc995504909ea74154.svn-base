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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmAngsuranBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridPenjualan, GridAngsuran, GridPelunasan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPenjualan;

        DateTime _fromDate, _toDate;
        double _saldo, _saldoUM, _saldoBunga;
        Guid _penjHistID, _penjRowID, _rowID;
        String _cabangID = GlobalVar.CabangID;
        String _flagSource;

        bool flagOverRefinance = false;
        bool flagOverTempoFLT = false;
        bool flagOverTempoAPD = false;
        bool PINKwitansi = false;
        int _typekettagih = 0;
        Guid _rowidtagih = Guid.NewGuid();

        public frmAngsuranBrowse()
        {
            InitializeComponent();
        }

        private void LoadPenjualan()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenjualanKredit_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                cmdANGSURAN.Enabled = false;
                cmdSimulasiBayar.Enabled = false;
                cmdPELUNASAN.Enabled = false;
                cmdTARIKAN.Enabled = false;
                cmdTarikanV2.Enabled = false;
                cmdRefinancing.Enabled = false;
                cmdTAMBAHUM.Enabled = false;
                cmdUBAHANG.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdPRINTKW.Enabled = false;
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

        private void LoadAngsuran()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridView2.DataSource = dt;
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

        private void LoadPembayaran()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST"));                        
                        db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();                       
                        gvAngsuranDetail.DataSource = dt;
                        
                    }

                    //tampilin angsuran batal
                    using (Database db = new Database())
                    {
                        //Guid penjrowid = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_BATAL"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowid", SqlDbType.UniqueIdentifier, _penjHistID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        GvBatalAngsuran.DataSource = dt;
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

        public void setTglTarikan(DateTime tgltarikan)
        {
            dataGridView1.SelectedCells[0].OwningRow.Cells["TarikanTgl2"].Value=tgltarikan;
        }


        public void LoadTitipanIden()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_DaftarTitipanSudahIden_ANG"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                        
                        dt = db.Commands[0].ExecuteDataTable();
                        gvTitipanGiro.DataSource = dt;
                        
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


        public void FindRowGrid1(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void FindRowGrid2(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }

        public void FindRowGrid3(string columnName, string value)
        {
            gvAngsuranDetail.FindRow(columnName, value);
        }

        private void frmAngsuranBrowse_Load(object sender, EventArgs e)
        {           
            if (GlobalVar.CabangID.ToUpper() == "06B" || GlobalVar.CabangID.ToUpper() == "06C" || GlobalVar.CabangID.ToUpper() == "06D" || GlobalVar.CabangID.ToUpper() == "06E")
            {
                _fromDate = new DateTime(2000, 1, 1); // khusus angsuran dikurangin 12 bulan (1 tahun) ke belakang
                _toDate = GlobalVar.GetServerDate;
                gvTitipanGiro.AutoGenerateColumns = false;

                rdtTanggal.FromDate = _fromDate;
                rdtTanggal.ToDate = _toDate;
            }
            else
            {
                _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-12); // khusus angsuran dikurangin 12 bulan (1 tahun) ke belakang
                _toDate = GlobalVar.GetServerDate;
                gvTitipanGiro.AutoGenerateColumns = false;

                rdtTanggal.FromDate = _fromDate;
                rdtTanggal.ToDate = _toDate;

                LoadPenjualan();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {                  
                _flagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                LoadAngsuran();
                loadKeteranganTagih();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count > 0) // tambahan baru setelah &&
            {
                _penjHistID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;               
                
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Angsuran_CEK_SALDO"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));     // sisa bayaran angsuran yg blom dibayar
                _saldoUM = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoUM"], 0)); // sisa bayaran um yg blom dibayar

                DateTime Tgl = GlobalVar.GetServerDate;

                string tglTarikan = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["TarikanTgl2"].Value, "").ToString();

                // khusus cabang TLA saldo um masih gede gpp
                if (GlobalVar.CabangID.Contains("06")) // && _flagSource == "BARU" karena ADS itu ORI
                {
                    if ((_saldo > 0)) // um udah lunas, angs belom
                    {
                        cmdANGSURAN.Enabled = true;
                        cmdSimulasiBayar.Enabled = true;
                        cmdPELUNASAN.Enabled = true;
                        cmdAdj.Enabled = true;
                        if (tglTarikan == "")
                        {
                            cmdTARIKAN.Enabled = true;
                            cmdTarikanV2.Enabled = false;
                        }
                        else
                        {
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = true;
                        }
                        
                        if (this.CekTglJT(_penjRowID, _cabangID, Tgl) == true)
                        {
                            cmdTAMBAHUM.Enabled = true;
                            if (this.CekKodeTrans(_penjRowID, _cabangID) == true) { cmdUBAHANG.Enabled = true; }
                            else { cmdUBAHANG.Enabled = false; }
                        }
                        else
                        {
                            cmdTAMBAHUM.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                        }
                        cmdDELETE.Enabled = false;
                        cmdBABPKB.Enabled = false;
                    }
                    else if ((_saldo <= 0))   // um dan angs udah lunas
                    {
                        cmdANGSURAN.Enabled = false;
                        cmdSimulasiBayar.Enabled = false;
                        cmdPELUNASAN.Enabled = false;
                        cmdAdj.Enabled = false;
                        cmdTARIKAN.Enabled = false;
                        cmdTarikanV2.Enabled = false;
                        cmdTAMBAHUM.Enabled = false;
                        cmdDELETE.Enabled = false;
                        cmdUBAHANG.Enabled = false;
                        cmdBABPKB.Enabled = true;
                    }
                }
                else
                {
                    if ((_saldo > 0) && (_saldoUM > 0)) // baik um dan angsuran masih belum lunas
                    {
                        cmdANGSURAN.Enabled = false;
                        cmdSimulasiBayar.Enabled = false;
                        cmdPELUNASAN.Enabled = false;
                        cmdAdj.Enabled = true;
                        cmdTARIKAN.Enabled = false;
                        cmdTarikanV2.Enabled = false;
                        cmdTAMBAHUM.Enabled = false;
                        cmdDELETE.Enabled = false;
                        cmdUBAHANG.Enabled = false;
                        cmdBABPKB.Enabled = false;
                    }
                    else if ((_saldo > 0) && (_saldoUM <= 0)) // um udah lunas, angs belom
                    {
                        cmdANGSURAN.Enabled = true;
                        cmdSimulasiBayar.Enabled = true;
                        cmdPELUNASAN.Enabled = true;
                        cmdAdj.Enabled = true;
                        cmdTARIKAN.Enabled = true;
                        cmdTarikanV2.Enabled = false;
                        if (this.CekTglJT(_penjRowID, _cabangID, Tgl) == true)
                        {
                            cmdTAMBAHUM.Enabled = true;
                            if (this.CekKodeTrans(_penjRowID, _cabangID) == true) { cmdUBAHANG.Enabled = true; }
                            else { cmdUBAHANG.Enabled = false; }
                        }
                        else
                        {
                            cmdTAMBAHUM.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                        }
                        cmdDELETE.Enabled = false;
                        cmdBABPKB.Enabled = false;
                    }
                    else if ((_saldo <= 0) && (_saldoUM <= 0))   // um dan angs udah lunas
                    {
                        cmdANGSURAN.Enabled = false;
                        cmdSimulasiBayar.Enabled = false;
                        cmdPELUNASAN.Enabled = false;
                        cmdAdj.Enabled = false;
                        cmdTARIKAN.Enabled = false;
                        cmdTarikanV2.Enabled = false;
                        cmdTAMBAHUM.Enabled = false;
                        cmdDELETE.Enabled = false;
                        cmdUBAHANG.Enabled = false;
                        cmdBABPKB.Enabled = true;
                    }
                    else if ((_saldo <= 0) && (_saldoUM > 0))   // angs lunas, um blom
                    {
                        cmdANGSURAN.Enabled = false;
                        cmdSimulasiBayar.Enabled = false;
                        cmdPELUNASAN.Enabled = false;
                        cmdAdj.Enabled = false;
                        cmdTARIKAN.Enabled = false;
                        cmdTarikanV2.Enabled = false;
                        cmdTAMBAHUM.Enabled = false;
                        cmdDELETE.Enabled = false;
                        cmdUBAHANG.Enabled = false;
                        cmdBABPKB.Enabled = false;
                    }
                }

                if (dataGridView2.RowCount > 0)
                {
                    LoadPembayaran();
                    LoadTitipanIden();
                }
                else
                {
                    DataTable dtClear = new DataTable();
                    dtClear.Clear();
                    gvAngsuranDetail.DataSource = dtClear;
                }

                if (dataGridView2.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count > 0) // tambahan baru setelah &&
                {
                    cekRefinancing();
                }

                if (GlobalVar.CabangID.Contains("06")) // karena ADS itu ORI  && _flagSource == "BARU"
                {
                    using (Database dbsub = new Database())
                    {
                        DataTable dtsub = new DataTable();
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanANG_GetLastInstallment"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                        dtsub = dbsub.Commands[0].ExecuteDataTable();
                        if(dtsub.Rows.Count > 0)
                        {
                            int Tempo = Convert.ToInt32(Tools.isNull(dataGridView2.SelectedCells[0].OwningRow.Cells["mTempoAngsuran"].Value, 24));
                            int lastInstallment = Convert.ToInt32(Tools.isNull(dtsub.Rows[0]["AngsuranTerakhir"], 1));

                            if (lastInstallment + 1 > (Tempo - 2))
                            {
                                cmdPELUNASAN.Enabled = true; //-- edit heri: sebelumnya false, meskipun terlambat berbulan bulan dibolehin PELUNASAN 30/apr/2015 10:50WIB Acc pak Novi
                                cmdAdj.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (gvAngsuranDetail.SelectedCells.Count > 0)
            {
                _rowID = (Guid)gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                DateTime Tgl = GlobalVar.GetServerDate;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                DataTable _dt = new DataTable();
                using (Database _db = new Database())
                {
                    _db.Commands.Add(_db.CreateCommand("usp_Angsuran_CEK_DELETE"));
                    _db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    _db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    _dt = _db.Commands[0].ExecuteDataTable();
                }

                string tglTarikan = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["TarikanTgl2"].Value, "").ToString();

                if ((bool)Tools.isNull(dt.Rows[0]["cetak"], false) == true)
                {
                    // khusus cabang TLA saldo um masih gede gpp
                    if (GlobalVar.CabangID.Contains("06") ) // karena ADS itu ORI && _flagSource == "BARU"
                    {
                        if ((_saldo > 0)) // um udah lunas, angs belom
                        {
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;
                            if (tglTarikan == "")
                            {
                                cmdTARIKAN.Enabled = true;
                                cmdTarikanV2.Enabled = false;
                            }
                            else
                            {
                                cmdTARIKAN.Enabled = false;
                                cmdTarikanV2.Enabled = true;
                            }
                            if (this.CekTglJT(_penjRowID, _cabangID, Tgl) == true)
                            {
                                cmdTAMBAHUM.Enabled = true;
                                if (this.CekKodeTrans(_penjRowID, _cabangID) == true) { cmdUBAHANG.Enabled = true; }
                                else { cmdUBAHANG.Enabled = false; }
                            }
                            else
                            {
                                cmdTAMBAHUM.Enabled = false;
                                cmdUBAHANG.Enabled = false;
                            }
                            cmdDELETE.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                        else if ((_saldo <= 0))   // um dan angs udah lunas
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = true;
                        }
                    }
                    else
                    {
                        if ((_saldo > 0) && (_saldoUM > 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                        else if ((_saldo > 0) && (_saldoUM == 0))
                        {
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;
                            cmdTARIKAN.Enabled = true;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = true;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                        else if ((_saldo == 0) && (_saldoUM == 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = true;
                        }
                        else if ((_saldo == 0) && (_saldoUM > 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                    }
                    cmdPRINTKW.Enabled = true;
                }
                else
                {
                    if (GlobalVar.CabangID.Contains("06")) // karena ADS itu ORI  && _flagSource == "BARU"
                    {
                        if ((_saldo > 0)) // um udah lunas, angs belom
                        {
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;
                            if (tglTarikan == "")
                            {
                                cmdTARIKAN.Enabled = true;
                                cmdTarikanV2.Enabled = false;
                            }
                            else
                            {
                                cmdTARIKAN.Enabled = false;
                                cmdTarikanV2.Enabled = true;
                            }
                            if (this.CekTglJT(_penjRowID, _cabangID, Tgl) == true)
                            {
                                cmdTAMBAHUM.Enabled = true;
                                if (this.CekKodeTrans(_penjRowID, _cabangID) == true) { cmdUBAHANG.Enabled = true; }
                                else { cmdUBAHANG.Enabled = false; }
                            }
                            else
                            {
                                cmdTAMBAHUM.Enabled = false;
                                cmdUBAHANG.Enabled = false;
                            }
                            cmdDELETE.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                        else if ((_saldo <= 0))   // um dan angs udah lunas
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = true;
                        }
                    }
                    else
                    {
                        if ((_saldo > 0) && (_saldoUM > 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                        else if ((_saldo > 0) && (_saldoUM == 0))
                        {
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;
                            if (tglTarikan == "")
                            {
                                cmdTARIKAN.Enabled = true;
                                cmdTarikanV2.Enabled = false;
                            }
                            else
                            {
                                cmdTARIKAN.Enabled = false;
                                cmdTarikanV2.Enabled = true;
                            }
                            cmdBABPKB.Enabled = false;
                            if (this.CekTglJT(_penjRowID, _cabangID, Tgl) == true)
                            {
                                cmdTAMBAHUM.Enabled = true;
                                if (this.CekKodeTrans(_penjRowID, _cabangID) == true) { cmdUBAHANG.Enabled = true; }
                                else { cmdUBAHANG.Enabled = false; }
                            }
                            else
                            {
                                cmdTAMBAHUM.Enabled = false;
                                cmdUBAHANG.Enabled = false;
                            }
                            if ((bool)Tools.isNull(_dt.Rows[0]["Boleh"], false) == true) { cmdDELETE.Enabled = true; }
                            else { cmdDELETE.Enabled = false; }
                        }
                        else if ((_saldo == 0) && (_saldoUM == 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = true;
                        }
                        else if ((_saldo == 0) && (_saldoUM > 0))
                        {
                            cmdANGSURAN.Enabled = false;
                            cmdSimulasiBayar.Enabled = false;
                            cmdPELUNASAN.Enabled = false;
                            cmdTARIKAN.Enabled = false;
                            cmdTarikanV2.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                        }
                    }
                    cmdPRINTKW.Enabled = true;
                }

                // kalo masih enabled cek ke journal
                if(cmdDELETE.Enabled == true)
                {
                    Guid penerimaanUangRowID = (Guid)Tools.isNull(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowID"].Value, Guid.Empty);
                    // cek data penerimaan angsurannya itu punya penerimaanrowid ngga 
                    if (penerimaanUangRowID == Guid.Empty || penerimaanUangRowID.ToString() == "" || penerimaanUangRowID == null)
                    {
                        // kalo kosong ya udah ga usah diapa2in
                    }
                    // kalo iya cek udah ada jurnal blom
                    else
                    {
                        // lakukan pengecekan kalo ada penerimaanUangRowID
                        using(Database db = new Database(GlobalVar.DBFinanceOto))
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CheckJournalByPenerimaanUangRowID"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
                            dummy = db.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if(dummy.Rows.Count > 0)
                            {
                                cmdDELETE.Enabled = false;
                            }
                        }

                        // cek lagi, kalau ada denda, dan dendanya itu udah masuk jurnal, ngga boleh juga
                        using (Database db = new Database(GlobalVar.DBShowroom))
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CheckJurnalDenda"));
                            db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "Angsuran"));
                            dummy = db.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if (dummy.Rows.Count > 0)
                            {
                                cmdDELETE.Enabled = false;
                            }
                        }
                        
                    }
                }

                if (dataGridView2.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count > 0) // tambahan baru setelah &&
                {
                    cekRefinancing();
                }

                if (GlobalVar.CabangID.Contains("06")) // karena ADS itu ORI && _flagSource == "BARU" 
                {
                    using (Database dbsub = new Database())
                    {
                        DataTable dtsub = new DataTable();
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanANG_GetLastInstallment"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                        dtsub = dbsub.Commands[0].ExecuteDataTable();
                        if (dtsub.Rows.Count > 0)
                        {
                            int Tempo = Convert.ToInt32(Tools.isNull(dataGridView2.SelectedCells[0].OwningRow.Cells["mTempoAngsuran"].Value, 24));
                            int lastInstallment = Convert.ToInt32(Tools.isNull(dtsub.Rows[0]["AngsuranTerakhir"], 1));

                            if (lastInstallment + 1 > (Tempo - 2))
                            {
                                cmdPELUNASAN.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void cekRefinancing()
        {
            PINKwitansi = false;
            // tiap kali cek refinance di reset dulu flag nya
            flagOverTempoFLT = false;
            flagOverRefinance = false;

            // tambahan, refinancing hanya berlaku buat tipe angsuran menurun, kalau flat ngga kena refinancing, boleh bayar angsuran terus
            // tapi tiap kali bayar angsuran itu mesti minta pin
            String tipeAngsuran = dataGridView2.SelectedCells[0].OwningRow.Cells["KodeTrans"].Value.ToString();
            // kalo udah lunas ngga perlu ke bawah sinni, kalau belum baru diapa2in
            Double saldoPokok = Convert.ToDouble(Tools.isNull(dataGridView2.SelectedCells[0].OwningRow.Cells["mSaldoPokok"].Value, 0).ToString());

            string tglTarikan = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["TarikanTgl2"].Value, "").ToString();

            if (saldoPokok > 0) // kalo masih ada saldo pokok, berarti belum lunas
            {
                // pengecekan tarikan ini mesti dimerge sama cek nya refinance
                // ambil data tempo angsuran, tgl awal angsuran
                DateTime tglAwalAngs = Convert.ToDateTime(Tools.isNull(dataGridView2.SelectedCells[0].OwningRow.Cells["mTglAwalAngs"].Value, DateTime.MinValue).ToString());
                int tempoAngsuran = Convert.ToInt32(Tools.isNull(dataGridView2.SelectedCells[0].OwningRow.Cells["mTempoAngsuran"].Value, 0).ToString());
                String NoTransaksi = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["NoTransaksi"].Value, "").ToString();

                if (tipeAngsuran == "FLT" && Math.Abs((tglAwalAngs - GlobalVar.GetServerDate).Days / 30) > tempoAngsuran)
                {
                    // berarti ini transaksi angsuran FLAT yg udah lewat angsurannya
                    cmdTARIKAN.Enabled = true;
                    cmdPELUNASAN.Enabled = true;

                    flagOverTempoFLT = true; // tandain udah over tempo angsuran flatnya
                    cmdANGSURAN.Enabled = true;
                    cmdSimulasiBayar.Enabled = true;
                    cmdPELUNASAN.Enabled = true;

                    cmdRefinancing.Enabled = false;
                    cmdTAMBAHUM.Enabled = false;
                    cmdDELETE.Enabled = false;
                    cmdUBAHANG.Enabled = false;
                    cmdBABPKB.Enabled = false;
                    cmdPRINTKW.Enabled = true; //  -- pin  false;
                    PINKwitansi = true;
                }
                else if (tipeAngsuran == "APD")
                {
                    if (NoTransaksi.Substring(NoTransaksi.Length - 1, 1).ToLower() == "r") // berarti udah pernah di refinance
                    {
                        // cek udah kelewatan lagi belum temponya
                        if (Math.Abs((tglAwalAngs - GlobalVar.GetServerDate).Days / 30) > tempoAngsuran)
                        {
                            // berarti kelewatan lagi, tetep bolehin bayar angsuran, tapi ngga bisa refinancing paling tarikan normalnya
                            cmdTARIKAN.Enabled = true;

                            flagOverRefinance = true; // tandain udah over refinance
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;

                            cmdRefinancing.Enabled = false;
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                            cmdPRINTKW.Enabled = true; //  -- pin  false;
                            PINKwitansi = true;
                        }
                    }
                    else
                    {
                        // berarti belum pernah kena refinance
                        if (Math.Abs((tglAwalAngs - GlobalVar.GetServerDate).Days / 30) > tempoAngsuran)
                        {
                            // berarti kelewatan, disable kecuali tarikan dan refinancing
                            cmdRefinancing.Enabled = true;
                            if (tglTarikan == "")
                            {
                                cmdTARIKAN.Enabled = true;
                                cmdTarikanV2.Enabled = false;
                            }
                            else
                            {
                                cmdTARIKAN.Enabled = false;
                                cmdTarikanV2.Enabled = true;
                            }

                            flagOverTempoAPD = true; // tandain udah over tempo angsuran APDnya
                            cmdANGSURAN.Enabled = true;
                            cmdSimulasiBayar.Enabled = true;
                            cmdPELUNASAN.Enabled = true;
                            
                            cmdTAMBAHUM.Enabled = false;
                            cmdDELETE.Enabled = false;
                            cmdUBAHANG.Enabled = false;
                            cmdBABPKB.Enabled = false;
                            cmdPRINTKW.Enabled = true; //  -- pin  false;
                            PINKwitansi = true;
                        }
                        else
                        {
                            cmdRefinancing.Enabled = false;
                            cmdTARIKAN.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                cmdRefinancing.Enabled = false;
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPenjualan;
            dataGridView1_SelectionChanged(sender, e);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridAngsuran;
            dataGridView2_SelectionChanged(sender, e);
        }

        private void dataGridView3_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPelunasan;
            dataGridView3_SelectionChanged(sender, e);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshRowLunas(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                gvAngsuranDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            }
        }

        public void RefreshRowANG(Guid penjRowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtRefresh;
            }
        }

        private void cmdPELUNASAN_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan) &&
                dataGridView1.SelectedCells.Count > 0)
            {
                if (flagOverRefinance == true) // kalo kena over refinance, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.Refinance_Pelunasan_Kelewatan), "Data Penjualan sudah melewati Tempo yg ditetapkan dan sudah pernah melakukan proses Refinancing! Perlu PIN untuk melakukan Pelunasan");
                    if (GlobalVar.pinResult == false) { return; }
                }
                if (flagOverTempoFLT == true) // kalo kena over tempo, yg FLT tapi udah lewat tempo dan masih bayar, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PelunasanOverTempoFLT), "Data Angsuran Tetap sudah melewati tempo angsuran, untuk melakukan Pelunasan perlu PIN persetujuan!");
                    if (GlobalVar.pinResult == false) { return; }
                }
                if (flagOverTempoAPD == true) // kalo kena over tempo, yg APD tapi udah lewat tempo dan masih bayar, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PelunasanOverTempoAPD), "Data Angsuran APD sudah melewati tempo angsuran, untuk melakukan Pelunasan perlu PIN persetujuan!");
                    if (GlobalVar.pinResult == false) { return; }
                }
                Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "Pelunasan");
                ifrmChild.ShowDialog();
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (selectedGrid == enumSelectedGrid.GridPelunasan)
            {
                if (gvAngsuranDetail.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isOKTarikan = true;
                        _rowID = (Guid)gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;

                        String KodeTrans = gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["KodeTransDetail"].Value.ToString();

                        // kalo KodeTrans nya itu 'TRK' mesti cek, udah dilakukan penjualan belum data tarikannya
                        if (KodeTrans == "TRK")
                        {
                            DataTable dummy = new DataTable();
                            using (Database dbsub = new Database(GlobalVar.DBShowroom))
                            {
                                dbsub.Commands.Add(dbsub.CreateCommand("usp_Pembelian_GET_Tarikan"));
                                dbsub.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                dummy = dbsub.Commands[0].ExecuteDataTable();
                            }
                            if (dummy.Rows.Count > 0)
                            {
                                if (String.IsNullOrEmpty(dummy.Rows[0]["Result"].ToString()))
                                {
                                    // kalo data TglJual (Result) yg dikembalikan itu kosong/NULL, berarti boleh dihapus
                                }
                                else
                                {
                                    // kalo ngga kosong, berarti itu berisi tanggal, ngga boleh dihapus
                                    isOKTarikan = false;
                                }
                            }
                        }

                        if (isOKTarikan == false)
                        {
                            MessageBox.Show("Data tarikan sudah digunakan untuk penjualan, tidak dapat dihapus !");
                        }
                        else
                        {
                            if (Class.PenerimaanUang.checkDelete(_rowID, "PenerimaanAngsuran") == true)
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusKwitansiAngsuran), "Hapus Pelunasan Angsuran.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            Database db = new Database();
                            int looper = 0, counterdb = 0;
                            try
                            {
                                // kalo udah masuk sampe sini berarti emang udah boleh melakukan delete
                                if (KodeTrans == "TRK")
                                {
                                    // lakukan revert data tarikan
                                    db.Commands.Add(db.CreateCommand("usp_RevertTarikan_Penjualan"));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                    counterdb++;
                                }

                                db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_DELETE"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                counterdb++;

                                db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipanIden_DELETE"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Angsuran));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@RowIDTransaksi", SqlDbType.UniqueIdentifier, _rowID));
                                counterdb++;

                                db.BeginTransaction();
                                for (looper = 0; looper < counterdb; looper++)
                                {
                                    db.Commands[looper].ExecuteNonQuery();
                                }
                                db.CommitTransaction();
                            }
                            catch (Exception ex)
                            {
                                db.RollbackTransaction();
                                MessageBox.Show("Error terjadi, DELETE dibatalkan \n" + ex.Message);
                            }

                            gvAngsuranDetail.Rows.Remove(gvAngsuranDetail.SelectedCells[0].OwningRow);
                            this.RefreshRowANG(_penjRowID);
                            this.FindRowGrid2("mRowID", _penjHistID.ToString());
                            MessageBox.Show("Data berhasil dihapus");
                        }
                    }
                }
            }
        }

        private bool CekTglJT(Guid PenjRowID, String CabangID, DateTime Tanggal)
        {
            bool boleh = true;
            try
            {
                /*
                Command cmd_ = new Command(new Database(), CommandType.Text,
                                                         "SELECT TglJT                            " +
                                                         "  FROM dbo.PenerimaanAngsuran           " +
                                                         " WHERE PenjRowID = @PenjRowID           " +
                                                         "   AND CabangID = @CabangID             " + 
                                                         "   AND KodeTrans IN ('APD','FLT')       " +
                                                         "   AND AngsuranKe IN                    " +
                                                         "   ( SELECT MAX(AngsuranKe)             " +
                                                         "       FROM dbo.PenerimaanAngsuran      " +
                                                         "      WHERE PenjRowID = @PenjRowID      " +
                                                         "        AND CabangID = @CabangID        " + 
                                                         "        AND KodeTrans IN ('APD','FLT')  " +
                                                         "   )                                    ");
                cmd_.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID);
                cmd_.AddParameter("@CabangID", SqlDbType.VarChar, CabangID);
                */                             
                DataTable dt_ = new DataTable();
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CheckTglJT"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                    db.Commands[0].ExecuteNonQuery();
                    dt_ = db.Commands[0].ExecuteDataTable();
                }

                if (dt_.Rows.Count > 0)
                {
                    DateTime tgl_ = (DateTime)dt_.Rows[0]["TglJT"];

                    if ((Tanggal.Month.ToString() == tgl_.Month.ToString()) && (Tanggal.Year.ToString() == tgl_.Year.ToString()))
                    {
                        boleh = true;
                    }
                    else
                    {
                        boleh = false;
                    }
                }
                else
                {
                    boleh = false;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return boleh;
        }

        private bool CekKodeTrans(Guid PenjRowID, String CabangID)
        {
            bool boleh = true;
            try
            {   /*
                Command cmd_ = new Command(new Database(), CommandType.Text,
                                                         "SELECT TOP 1 KodeTrans           " +
                                                         "  FROM dbo.PenerimaanAngsuran    " +
                                                         " WHERE PenjRowID = @PenjRowID    " +
                                                         "   AND CabangID = @CabangID      " +
                                                         " ORDER BY LastUpdatedOn DESC     ");
                cmd_.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID);
                cmd_.AddParameter("@CabangID", SqlDbType.VarChar, CabangID);
                DataTable dt_ = cmd_.ExecuteDataTable();
                */
                DataTable dt_ = new DataTable();
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetKodeTransPenerimaanAngsuran"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                    db.Commands[0].ExecuteNonQuery();
                    dt_ = db.Commands[0].ExecuteDataTable();
                }

                if (dt_.Rows.Count > 0)
                {
                    String kdTrans = dt_.Rows[0]["KodeTrans"].ToString();

                    if (kdTrans == "APD")
                    {
                        boleh = true;
                    }
                    else
                    {
                        boleh = false;
                    }
                }
                else
                {
                    boleh = false;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return boleh;
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPelunasan)
                {
                    if (gvAngsuranDetail.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                        string _edp, _terbilang, _kotatgl, _kota, _copy, _uraian;
                        int _nprint;
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        if (PINKwitansi == true)
                        { 
                            // sebelumnya PinId.Bagian.Keuangan
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah melewati tempo angsuran !");
                            if (GlobalVar.pinResult == false) { return; }
                        }

                        frmPrint ifrmDialog = new frmPrint(this, 3);
                        ifrmDialog.ShowDialog();
                        if (ifrmDialog.DialogResult == DialogResult.Yes)
                        { _nprint = ifrmDialog.Result; }
                        else
                        { return; }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanANG"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            string kdtran = Tools.isNull(dt.Rows[0]["KodeTrans"].ToString(), "").ToString();
                            int JamBebasPIN = 0;
                            DataTable dummyPIN = new DataTable();
                            using (Database dbsubPIN = new Database())
                            {
                                dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                                dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                                dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                                JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                            }

                            DateTime LastPrintedOn;
                            LastPrintedOn = (DateTime) Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                            if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                            {
                            }
                            else
                            {
                                if ((bool)dt.Rows[0]["Cetak"] == true)
                                {
                                    // sebelumnya PinId.Bagian.Keuangan
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }
                            }
                            _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                            int angka = int.Parse(Tools.isNull(dt.Rows[0]["Nominal"], "0").ToString(), NumberStyles.Currency) + int.Parse(Tools.isNull(dt.Rows[0]["NominalPembulatan"], "0").ToString(), NumberStyles.Currency);
                            _terbilang = Tools.Terbilang(angka) + "RUPIAH";
                            _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                            _kota = _kota.Replace("Kota ", "");
                            _kota = _kota.Replace("Kabupaten ", "");

                            DateTime tglBayar;
                            tglBayar = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"].ToString(), GlobalVar.GetServerDate).ToString());
                            // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                            _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                            if ((bool)dt.Rows[0]["Cetak"] == true)
                            {
                                if (int.Parse(dt.Rows[0]["nPrint"].ToString()) > 0)
                                {
                                    _copy = "Copy ke-" + dt.Rows[0]["nPrint"].ToString();
                                }
                                else
                                {
                                    _copy = "";
                                }
                            }
                            else
                            {
                                _copy = "";
                            }

                            String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileName = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_Path = IMG_Path + FileName;
                            rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));

                            String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileNameBW = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_PathBW = IMG_PathBW + FileNameBW;
                            rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));

                            // kalau di TLA maunya ditampilin totalan di atasnya aja, pokok, bunga sama pembulatan dilewatin
                            if (GlobalVar.CabangID.Contains("06"))
                            {
                                rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["NominalTotal"]).ToString()));
                                // pokok, bunga sama pembulatan jadiin 0

                                dt.Rows[0]["Nominal"] = dt.Rows[0]["NominalTotal"];
                                dt.Rows[0]["NominalPokok"] = 0;
                                dt.Rows[0]["Bunga"] = 0;
                                dt.Rows[0]["NominalPembulatan"] = 0;
                            }

                            if(GlobalVar.CabangID.Contains("06"))
                            {
                                dt.Rows[0]["NoFaktur"] = dt.Rows[0]["NoFaktur"].ToString().Trim() + " - " + dt.Rows[0]["NoTransPJL"].ToString().Trim();
                            }

                            if (kdtran == "TRK")
                            {
                                rptParams.Add(new ReportParameter("JnsKw", "Tarikan"));
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("JnsKw", Tools.isNull(dt.Rows[0]["Uraian"], "").ToString()));
                            }
                            rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  // GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                            
                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                            rptParams.Add(new ReportParameter("Tipe", "ANG"));
                            
                            if ((_nprint == 0) || (_nprint == 1))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansi.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 2))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy1.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 3))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy2.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            cmdDELETE.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

            LoadPenjualan();
        }

        private void cmdANGSURAN_Click(object sender, EventArgs e)
        {   
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (flagOverRefinance == true) // kalo kena over refinance, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.Refinance_Bayar_Kelewatan), "Data Penjualan sudah melewati Tempo yg ditetapkan dan sudah pernah melakukan proses Refinancing!");
                    if (GlobalVar.pinResult == false) { return; }
                }
                if (flagOverTempoFLT == true) // kalo kena over tempo, yg FLT tapi udah lewat tempo dan masih bayar, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.AngsuranOverTempoFLT), "Data Angsuran Tetap sudah melewati tempo angsuran, untuk melakukan pembayaran perlu PIN persetujuan!");
                    if (GlobalVar.pinResult == false) { return; }
                }
                if (flagOverTempoAPD == true) // kalo kena over tempo, yg APD tapi udah lewat tempo dan masih bayar, pas klik ini ada pin harusnya
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.AngsuranOverTempoAPD), "Data Angsuran APD sudah melewati tempo angsuran, untuk melakukan pembayaran perlu PIN persetujuan!");
                    if (GlobalVar.pinResult == false) { return; }
                }

                // kalo pas bayar angsuran ada data giro diterima atau giro disetor, tapi untuk angsuran yg sama ya, berarti ambil maxnya dari angsuran yg udah pernah dibayar ( di gv yg satunya)
                /*
                int angsuranke_terakhir = 0;
                int looper = 0;
                for (looper = 0; looper < gvAngsuranDetail.Rows.Count; looper++)
                {
                    if (angsuranke_terakhir < Convert.ToInt32(gvAngsuranDetail.Rows[looper].Cells["AngsKe"].Value.ToString()))
                    {
                        angsuranke_terakhir = Convert.ToInt32(gvAngsuranDetail.Rows[looper].Cells["AngsKe"].Value.ToString());
                    }
                }
                */
                int ada_titipan = 0;
                int looper = 0;
                for (looper = 0; looper < gvTitipanGiro.Rows.Count; looper++)
                {
                    if (
                        gvTitipanGiro.Rows[looper].Cells["StatusBGC"].Value.ToString().ToLower() == "giro diterima"
                        ||
                        gvTitipanGiro.Rows[looper].Cells["StatusBGC"].Value.ToString().ToLower() == "giro disetor"
                      )
                    {
                        ada_titipan++;
                    }
                }
                bool lanjut = true;
                if (ada_titipan > 0)
                {
                    var confirmResult = MessageBox.Show("Masih adda data giro ditangan yg belum cair, yakin melakukan pembayaran lagi?",
                            "Confirm Payment!!",
                            MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        lanjut = true;
                    }
                    else
                    {
                        lanjut = false;
                    }
                }
                if (lanjut == true)
                {
                    Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "Angsuran");
                    ifrmChild.ShowDialog();
                }
            }
        }

        private void cmdTARIKAN_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                //if (dataGridView1.SelectedCells.Count > 0)
                //{
                //    String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                //    if (FlagSource == "BARU")
                //    {
                //        // MessageBox.Show("Data BARU tidak dapat dilakukan penarikan!");
                //        // bisa tarikan
                //        Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "Tarikan");
                //        ifrmChild.ShowDialog();
                //    }
                //    else
                //    {
                //        Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "Tarikan");
                //        ifrmChild.ShowDialog();
                //    }
                //}

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    //String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                    //if (FlagSource == "BARU")
                    //{
                        // MessageBox.Show("Data BARU tidak dapat dilakukan penarikan!");
                        // bisa tarikan
                        Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "TarikanNV1");
                        ifrmChild.ShowDialog();
                    //}
                    //else
                    //{
                    //    Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "TarikanNV1");
                    //    ifrmChild.ShowDialog();
                    //}
                }
            }
        }

        private void cmdTarikanV2_Click(object sender, EventArgs e)
        {
            //_saldoBunga = Convert.ToDouble(dataGridView2.SelectedCells[0].OwningRow.Cells["mSaldoBunga"].Value);
            //if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            //{
            //    if (dataGridView1.SelectedCells.Count > 0)
            //    {
            //        String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
            //        if (FlagSource == "BARU")
            //        {
            //            Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, _saldoBunga, "Tarikanv2");
            //            ifrmChild.ShowDialog();
            //        }
            //        else
            //        {
            //            Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, _saldoBunga, "Tarikanv2");
            //            ifrmChild.ShowDialog();
            //        }
            //    }
            //}
            //MessageBox.Show("Temporary disabled.");

            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                    if (FlagSource == "BARU")
                    {
                        // MessageBox.Show("Data BARU tidak dapat dilakukan penarikan!");
                        // bisa tarikan
                        Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "TarikanNV2");
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "TarikanNV2");
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }

        private void cmdTAMBAHUM_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                    if (FlagSource == "BARU")
                    {
                        MessageBox.Show("Data BARU tidak dapat melakukan penambahan Uang Muka!");
                    }
                    else
                    {
                        Penjualan.frmAngsuranChange ifrmChild = new Penjualan.frmAngsuranChange(this, _penjHistID, _penjRowID, "UMT");
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }

        /* // mau diubah jadi refinancing
        private void cmdUBAHANG_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                Penjualan.frmAngsuranChange ifrmChild = new Penjualan.frmAngsuranChange(this, _penjHistID, _penjRowID, "UbahAngsuran");
                ifrmChild.ShowDialog();
            }
        }
        */
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

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView2.Rows)
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

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvAngsuranDetail.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gvAngsuranDetail.Rows)
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
        private void cmdBABPKB_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value; // grid1 itu data penjualan

                    if (!GlobalVar.CabangID.Contains("06"))
                    {
                        // cek dulu apakah denda nya ada yg belum lunas, minta lunasin dulu baru bisa pelunasan
                        _penjRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        using (Database db = new Database())
                        {
                            DataTable dtRefresh = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_CheckSaldo"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            dtRefresh = db.Commands[0].ExecuteDataTable();
                            if (dtRefresh.Rows.Count > 0)
                            {
                                Double SaldoDenda = Convert.ToDouble(Tools.isNull(dtRefresh.Rows[0]["SaldoDenda"], 0).ToString());
                                if (SaldoDenda > 0)
                                {
                                    MessageBox.Show("Tolong lunasi denda terlebih dahulu sebelum melakukan Pencetakan!");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {

                        // pas mau print ba bpkb ini perlu cek data denda mesti lunas baru boleh cetak
                        DataTable dtdummy = new DataTable();
                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanDendaxPenerimaanUMBunga_CheckSaldo"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            dtdummy = dbsub.Commands[0].ExecuteDataTable();
                        }
                        if (dtdummy.Rows.Count > 0)
                        {
                            Double BayarDenda = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["DendaSumBayar"], 0).ToString());
                            Double BayarUMBunga = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["UMBungaSumBayar"], 0).ToString());
                            Double TotalDenda = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["DendaSum"], 0).ToString());
                            Double TotalUMBunga = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["UMbungaSum"], 0).ToString());

                            if (BayarDenda < TotalDenda)
                            {
                                MessageBox.Show("Ada nominal Denda yang masih belum dibayarkan, mohon diurus terlebih dahulu sebelum melakukan proses ini!");
                                return;
                            }
                        }
                    }

                    bool pass = false;
                    if(GlobalVar.CabangID.Contains("06"))
                    {
                        Penjualan.frmBABPKB_TLA ifrmChild = new Penjualan.frmBABPKB_TLA(this, rowID);
                        ifrmChild.ShowDialog();
                        string result = ifrmChild.result;
                        if (result == "print") // ini berarti mau print
                        {
                            pass = true;
                        }
                    }
                    else
                    {
                        pass = true;
                    }

                    if (pass)
                    {
                        string _bulan;
                        string _tanggal;
                        string _tahun;
                        string _hari;
                        string _copy;

                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("rpt_BABPKB_Penjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].Parameters.Clear();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            int JamBebasPIN = 0;
                            DataTable dummyPIN = new DataTable();
                            using (Database dbsubPIN = new Database())
                            {
                                dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                                dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                                dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                                JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                            }

                            DateTime LastPrintedOn;
                            LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintBABPKBOn"], DateTime.MaxValue);
                            if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                            {
                            }
                            else
                            {
                                if (Tools.isNull(dt.Rows[0]["PrintBABPKB"], "").ToString().Trim() == "")
                                {
                                    MessageBox.Show("Data tidak Valid untuk jumlah kali pencetakan BABPKB!");
                                }
                                else if ((int)dt.Rows[0]["PrintBABPKB"] > 1)
                                {
                                    // sebelumnya PinId.Bagian.Keuangan
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PrintBABPKBPenjualan), "Sudah dilakukan cetak BABPKB !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }
                            }

                            _tanggal = GlobalVar.GetServerDate.Day.ToString();
                            _bulan = Tools.BulanPanjang(GlobalVar.GetServerDate.Month);
                            _tahun = GlobalVar.GetServerDate.Year.ToString();
                            _hari = Tools.HariPanjang(GlobalVar.GetServerDate);

                            rptParams.Add(new ReportParameter("Date", GlobalVar.GetServerDate.ToString("yyyy-MM-dd")));
                            rptParams.Add(new ReportParameter("PrintBy", SecurityManager.UserID.ToString()));
                            rptParams.Add(new ReportParameter("Now", GlobalVar.GetServerDate.ToString()));

                            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_CounterBABPKB"));
                            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[1].Parameters.Add(new Parameter("@LastPrintedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[1].ExecuteNonQuery();

                            frmReportViewer ifrmReport1 = new frmReportViewer("Penjualan.rptBABPKB.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                            ifrmReport1.Print();

                        }
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cmdRefinancing_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                Penjualan.frmAngsuranRefinance ifrmChild = new Penjualan.frmAngsuranRefinance(this, _penjRowID, _penjHistID);
                ifrmChild.ShowDialog();
            }
        }

        private void cmdSimulasiBayar_Click(object sender, EventArgs e)
        {
            Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "Angsuran", true);
            ifrmChild.ShowDialog();
        }

        
        private void CmdBatal_Click(object sender, EventArgs e) // tambahan heri on 13 mei 2015
        {
            Database dbRollBack = new Database();
            int CounterDb = 0;
            try
            {
                if (gvAngsuranDetail.SelectedCells.Count > 0)
                {
                    //cek bulannya, kalau beda bulan jangan dibolehin batal 
                    string MonthServer = GlobalVar.GetServerDate.Month.ToString();
                    DateTime tanggalAngsBat = Convert.ToDateTime(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["Tanggal"].Value.ToString());
                    string MonthBatal = tanggalAngsBat.Month.ToString();
                    if (MonthBatal == MonthServer)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Sudah beda bulan, Anda tidak diperkenankan membatalkan Angsuran ini...");
                        return;
                    }

                   
                    //cek denda 
                    double denda = Convert.ToDouble(Tools.isNull(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["Denda"].Value, 0).ToString());
                    double bayardenda = Convert.ToDouble(Tools.isNull(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["BayarDenda"].Value, 0).ToString());
                    string jenisPemb = gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["BentukPembayaranText"].Value.ToString();
                    string uraian = gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                    string konsumen = dataGridView1.SelectedCells[0].OwningRow.Cells["Customer"].Value.ToString();
                    string angsuranke = gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["AngsKe"].Value.ToString();
                    DateTime tanggalAngs = Convert.ToDateTime(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["Tanggal"].Value.ToString());
                    Guid rowID = (Guid)gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;

                    double nomPotongan = Convert.ToDouble(Tools.isNull(gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["PotonganPLS"].Value, 0).ToString());
                    
                    DataTable dtCekJurnal = new DataTable(); //cek udah di link jurnal belum, Heri
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_CekJournal"));
                        db.Commands[0].Parameters.Add(new Parameter("@AngsRowID", SqlDbType.UniqueIdentifier, rowID));
                        dtCekJurnal = db.Commands[0].ExecuteDataTable();
                    }

                    
                    if (tanggalAngs <= GlobalVar.GetServerDate.Date.AddDays(-3))
                    {
                        MessageBox.Show("Anda hanya diperkenankan membatalkan angsuran yang diinput hari ini atau kemarin..");
                        return;
                    }
                    else if (dtCekJurnal.Rows.Count > 0)
                    {
                        MessageBox.Show("Angsuran telah dilink journal, tidak diperkenankan membatalkan angsuran ini..");
                        return;
                    }
                    else if (jenisPemb != "TUNAI")
                    {
                        MessageBox.Show("Fiture ini hanya bisa digunakan untuk bentuk pembayaran tunai..");
                        return;
                    }
                    else if (uraian.Contains("Migrasi"))
                    {
                        MessageBox.Show("Angsuran migrasi tidak dapat dibatalkan..");
                        return;
                    }
                    else if (uraian.Contains("MIG"))
                    {
                        MessageBox.Show("Angsuran migrasi tidak dapat dibatalkan..");
                        return;
                    }
                    //else if (uraian.Contains("PELUNASAN"))
                    //{
                    //    MessageBox.Show("Pelunasan tidak dapat dibatalkan..");
                    //    return;
                    //}
                    else if (denda > 0)
                    {
                        if (MessageBox.Show("Anda akan membatalkan Angsuran " + konsumen.ToString() + ",Angsuran ke " + angsuranke.ToString() + " ?", "Konfirmasi Batal Angsuran", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            return;
                        }
                        //PIN
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PotonganPenerimaanDenda), "Pembatalan memerlukan PIN persetujuan bagian Accounting..");
                        if (GlobalVar.pinResult == false)
                        {
                            return;
                        }
                        else
                        {
                        }
                        DataTable dt;
                        //cek denda sudah dibayar belum
                        using (Database dbDendaBayar = new Database())
                        {
                            dbDendaBayar.Commands.Add(dbDendaBayar.CreateCommand("usp_penerimaanDenda_Batal_Bayar"));
                            dbDendaBayar.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = dbDendaBayar.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            int bayardenda_ = Convert.ToInt32(dt.Rows[0]["NominalBayar"].ToString());
                            int pembulatandenda_ = Convert.ToInt32(dt.Rows[0]["PembulatanBayar"].ToString());
                            if (bayardenda_ == 1 && pembulatandenda_ == 1)
                            {
                                //bkk penerimaan denda
                                String bentukPengeluaran = "K";
                                string NoTransPengeluaran;
                                Database dbfNumerator;
                                dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                                           string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);


                                //using (Database dbDendaBKK = new Database())
                                //{
                                    dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanDenda_BATAL_BKK"));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    //dbRollBack.Commands[CounterDb].ExecuteNonQuery();
                                    CounterDb++;
                                //}
                                //bkk penerimaan denda bulat                    
                                dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                                           string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);

                                //using (Database dbDendaBKK = new Database())
                                //{
                                    dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanDenda_BATAL_BKKBLT"));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    //dbRollBack.Commands[0].ExecuteNonQuery();
                                    CounterDb++;
                                //}
                            }
                            else if (bayardenda_ == 1 && pembulatandenda_ == 0)
                            {
                                //bkk penerimaan denda
                                String bentukPengeluaran = "K";
                                string NoTransPengeluaran;
                                Database dbfNumerator;
                                dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                                           string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);


                                //using (Database dbDendaBKK = new Database())
                                //{
                                    dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanDenda_BATAL_BKK"));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    //dbDendaBKK.Commands[0].ExecuteNonQuery();
                                CounterDb++;
                                //}
                            }
                        }
                        // pindahkan data penerimaandenda tsb ke table penerimaandendadel kemudian delete dari table aslinya
                        //using (Database db = new Database())
                        //{
                            dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_PenerimaanDenda_BATAL"));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@DeletedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            //db.Commands[0].ExecuteNonQuery();
                            CounterDb++;
                        //}

                        // Cek Potongan 
                        if (nomPotongan > 0)
                        {
                            //bkk penerimaan potongan
                            String bentukPenerimaan = "K";
                            string NoTransPenerimaanPot;
                            Database dbfNumerator;
                            dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            NoTransPenerimaanPot = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPenerimaan + "M/" +
                                                                       string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);


                            dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_PotonganAngsuran_BATAL"));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, NoTransPenerimaanPot.ToString()));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                            CounterDb++;
                            //}
                        }


                        BatalAngsuran(ref dbRollBack, ref CounterDb);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda akan membatalkan Angsuran " + konsumen.ToString() + ",Angsuran ke " + angsuranke.ToString() + " ?", "Konfirmasi Batal Angsuran", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            return;
                        }
                        //PIN
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PotonganPenerimaanDenda), "Pembatalan memerlukan PIN persetujuan bagian Accounting... ");
                        if (GlobalVar.pinResult == false)
                        {
                            return;
                        }
                        else
                        {
                        }

                        // Cek Potongan 
                        if (nomPotongan > 0)
                        {
                            //bkk penerimaan potongan
                            String bentukPenerimaan = "K";
                            string NoTransPenerimaanPot;
                            Database dbfNumerator;
                            dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            NoTransPenerimaanPot = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPenerimaan + "M/" +
                                                                       string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);


                            dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_PotonganAngsuran_BATAL"));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, NoTransPenerimaanPot.ToString()));
                            dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                            CounterDb++;
                            //}
                        }

                        BatalAngsuran(ref dbRollBack, ref CounterDb);
                    }

                    if (CounterDb > 0)
                    {
                        dbRollBack.BeginTransaction();
                        for (int i = 0; i < CounterDb; i++)
                        {
                            dbRollBack.Commands[i].ExecuteNonQuery();
                        }
                        dbRollBack.CommitTransaction();
                        MessageBox.Show("Data angsuran " + konsumen.ToString() + " berhasil dibatalkan");
                        LoadPembayaran();
                    }
                }
            }
            catch (Exception ex)
            {
                dbRollBack.RollbackTransaction();
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BatalAngsuran(ref Database dbRollBack, ref int CounterDb)
        {
            string konsumen = dataGridView1.SelectedCells[0].OwningRow.Cells["Customer"].Value.ToString();
            Guid rowID = (Guid)gvAngsuranDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;

            Guid RowidUangkeluar = new Guid();
            Guid RowidUangKeluarBNG = new Guid();
            RowidUangkeluar = Guid.NewGuid();
            RowidUangKeluarBNG = Guid.NewGuid();
            DataTable dt;
            //cek angsuran ada pembulatan tidak
            using (Database dbBLTangs = new Database())
            {
                dbBLTangs.Commands.Add(dbBLTangs.CreateCommand("usp_penerimaanangs_blt"));
                dbBLTangs.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dt = dbBLTangs.Commands[0].ExecuteDataTable();                
            }

            //ciptakan BKK atas penerimaan angsuran tsb
            String bentukPengeluaran = "K";
            String NoTransPengeluaran;

            //bikin noBKK-pokok
            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
            NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);

            //using (Database dbBKK = new Database())
            //{
                dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanANG_BATAL_BKK"));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowidUangkeluar", SqlDbType.VarChar, RowidUangkeluar.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));                
                //dbBKK.Commands[0].ExecuteNonQuery();
                CounterDb++;
            //}           

            //bikin noBKK-bunga
            Database dbfNumeratorBNG = new Database(GlobalVar.DBFinanceOto);
            NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumeratorBNG, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);

            ////using (Database dbBKK = new Database())
            ////{
                dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanANG_BATAL_BKKBNG"));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowidUangKeluarBNG", SqlDbType.VarChar, RowidUangKeluarBNG.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                //dbRollBack.Commands[0].ExecuteNonQuery();
                CounterDb++;
            //}

            if (dt.Rows.Count > 0)
            {
                //bkk penerimaan angs bulat                    
                dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                           string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);

                //using (Database dbBKK = new Database())
                //{
                    dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_penerimaanANGS_BATAL_BKKBLT"));
                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                    dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //dbBKK.Commands[0].ExecuteNonQuery();
                    CounterDb++;
                //}
            }
            else
            {
            }

            // pindahkan data angsuran tsb ke table penerimaanangsurandel kemudian delete dari table aslinya
            //using (Database db = new Database())
            //{
                dbRollBack.Commands.Add(dbRollBack.CreateCommand("usp_PenerimaanANG_BATAL"));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowidUangkeluar", SqlDbType.VarChar, RowidUangkeluar.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@RowidUangkeluarBNG", SqlDbType.VarChar, RowidUangKeluarBNG.ToString()));
                dbRollBack.Commands[CounterDb].Parameters.Add(new Parameter("@DeletedBy", SqlDbType.VarChar, SecurityManager.UserID));
            //    db.Commands[0].ExecuteNonQuery();
                CounterDb++;
            //}
        }

        private void cmdAdj_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAngsuran) || (selectedGrid == enumSelectedGrid.GridPelunasan) &&
                dataGridView1.SelectedCells.Count > 0)
            {               
                Penjualan.frmAngsuranUpdate ifrmChild = new Penjualan.frmAngsuranUpdate(this, _penjHistID, _penjRowID, "ADJ");
                ifrmChild.ShowDialog();
            }
        }

        private void cmdAddKetTagih_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                _typekettagih = 0;
                if (cmdANGSURAN.Enabled == false)
                {
                    MessageBox.Show("Angsuran sudah Lunas");
                    return;
                }
                if (!cekAngsuran())
                {
                    return;
                }

                _rowidtagih = Guid.NewGuid();

                panelKetTagih.Visible = true;
                panelKetTagih.BringToFront();
                txtTglTagih.DateValue = GlobalVar.DateOfServer;
                txtKetTagih.Text = "";
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;
                tabControl1.Enabled = false;
            }
        }

        private void cmdSaveKetTagih_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKetTagih.Text == "")
                {
                    MessageBox.Show("Keterangan Tagih belum diisi");
                    return;
                }
                if (MessageBox.Show("Anda yakin ingin menyimpan keterangan tagih ?", "Insert Keterangan Tagih", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value; // grid1 itu data penjualan
                    using (Database db = new Database())
                    {
                        DataTable dtRefresh = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_KeteranganTagih_Insert"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowidtagih));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTagih", SqlDbType.DateTime, txtTglTagih.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Int, Convert.ToInt32(txtAngsuranKe.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, txtKetTagih.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.Int, _typekettagih));
                        dtRefresh = db.Commands[0].ExecuteDataTable();
                    }
                    panelKetTagih.Visible = false;
                    panelKetTagih.SendToBack();
                    dataGridView1.Enabled = true;
                    dataGridView2.Enabled = true;
                    tabControl1.Enabled = true;

                    loadKeteranganTagih();
                    GVKetTagih.FindRow("RowIDKetTagih", _rowidtagih.ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCancelTagih_Click(object sender, EventArgs e)
        {
            panelKetTagih.Visible = false;
            panelKetTagih.SendToBack();
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void loadKeteranganTagih()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value; // grid1 itu data penjualan
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_KeteranganTagih_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        GVKetTagih.DataSource = dt;

                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                GVKetTagih.DataSource = null;
            }
            
        }

        private void cmdDelKetTagih_Click(object sender, EventArgs e)
        {
            if (GVKetTagih.Rows.Count > 0)
            {
                _typekettagih = 1;
                _rowidtagih = (Guid)GVKetTagih.SelectedCells[0].OwningRow.Cells["RowIDKetTagih"].Value;

                panelKetTagih.Visible = true;
                panelKetTagih.BringToFront();
                txtTglTagih.DateValue = Convert.ToDateTime(GVKetTagih.SelectedCells[0].OwningRow.Cells["TglTagih"].Value);
                txtAngsuranKe.Text = GVKetTagih.SelectedCells[0].OwningRow.Cells["AngsuranKeKetTagih"].Value.ToString();
                txtKetTagih.Text = GVKetTagih.SelectedCells[0].OwningRow.Cells["KetTagih"].Value.ToString();
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;
                tabControl1.Enabled = false;
            }

            //try
            //{
            //    if (GVKetTagih.Rows.Count > 0)
            //    {
            //        
            //        if (MessageBox.Show("Anda yakin ingin menghapus keterangan tagih ?", "Insert Keterangan Tagih", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            return;
            //        }
            //        Guid _rowidtagih = (Guid)GVKetTagih.SelectedCells[0].OwningRow.Cells["RowIDKetTagih"].Value; // grid1 itu data penjualan
            //        using (Database db = new Database())
            //        {
            //            DataTable dtRefresh = new DataTable();
            //            db.Commands.Add(db.CreateCommand("usp_KeteranganTagih_Delete"));
            //            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowidtagih));
            //            dtRefresh = db.Commands[0].ExecuteDataTable();
            //        }

            //        loadKeteranganTagih();
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
        }

        private bool cekAngsuran()
        {
            bool _hasil = true;
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToDateTime(dt.Rows[0]["TglJTAngsuran"]) >= GlobalVar.GetServerDate)
                        {
                            _hasil = false;
                            MessageBox.Show("Tidak ada Angsuran yg melebihi Tgl Jatuh Tempo");
                        }

                        txtAngsuranKe.Text=Tools.isNull(dt.Rows[0]["AngsuranKe"], "0").ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return _hasil;
        }
    }
}
