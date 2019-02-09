using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmProsesGiroBrowse : ISA.Controls.BaseForm
    {
        enum _arahGiro { GiroMasuk, GiroKeluar, GiroMasukPiutang }
        enum enumStatusGiro { Diterima, Disetor, BatalSetor, Cair, BatalCair, Ditolak, Batal }
        public frmProsesGiroBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProsesGiroBrowse_Load(object sender, EventArgs e)
        {
            DateTime _fromDate, _toDate = new DateTime();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(1 - _toDate.Day);
            rgTglGiroMasuk.FromDate = _fromDate;
            rgTglGiroMasuk.ToDate = _toDate;
            rgTglGiroKeluar.FromDate = _fromDate;
            rgTglGiroKeluar.ToDate = _toDate; 
            rgTglGiroMasukPiutang.FromDate = _fromDate;
            rgTglGiroMasukPiutang.ToDate = _toDate;
            dataGridGiroMasuk.AutoGenerateColumns = false;
            dataGridGiroMasukPiutang.AutoGenerateColumns = false;
            dataGridGiroKeluar.AutoGenerateColumns = false;

            RefreshData();

 
           
        }

        #region UserDefineFunctions

        private void RefreshData()
        {
            RefreshGridMasuk();
            RefreshGridKeluar();
            RefreshGridMasukPiutang();
        }

        private void RefreshGridMasukPiutang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtMasuk = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_LIST_FILTER_Giro")); // [usp_PenerimaanTitipan_LIST_FILTER_Giro]
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rgTglGiroMasukPiutang.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rgTglGiroMasukPiutang.ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtMasuk = db.Commands[0].ExecuteDataTable();
                    dataGridGiroMasukPiutang.DataSource = dtMasuk;

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

        private void RefreshGridMasuk()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtMasuk = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_Giro"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rgTglGiroMasuk.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rgTglGiroMasuk.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    if ( (cboStatusGiroMasuk.SelectedIndex - 1) >= 0)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@StatusGiro", SqlDbType.NChar , (cboStatusGiroMasuk.SelectedIndex - 1)));
                    }
                    else if ( (cboStatusGiroMasuk.SelectedIndex - 1) < 0)
                    {
                    }
                    dtMasuk = db.Commands[0].ExecuteDataTable();
                    dataGridGiroMasuk.DataSource = dtMasuk;

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

        private void RefreshGridKeluar()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtKeluar = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST_FILTER_Giro"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rgTglGiroKeluar.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rgTglGiroKeluar.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtKeluar = db.Commands[0].ExecuteDataTable();
                    dataGridGiroKeluar.DataSource = dtKeluar;
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
        

        #endregion

        private void btnProses_Click(object sender, EventArgs e)
        {
            switch (tabGiro.SelectedIndex)
            {
                case 0:
                    {
                        if (dataGridGiroMasuk.SelectedCells.Count > 0)
                        {
                            Guid rowID = (Guid)dataGridGiroMasuk.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            String NoGiro = (String)dataGridGiroMasuk.SelectedCells[0].OwningRow.Cells["NoGiroMasuk"].Value;
                            DateTime TglJTGiro = (DateTime)dataGridGiroMasuk.SelectedCells[0].OwningRow.Cells["DueDateGiroMasuk"].Value; 

                            Keuangan.frmProsesGiroMasukUpdate ifrmChild = new Keuangan.frmProsesGiroMasukUpdate(this, rowID,NoGiro, TglJTGiro);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                        }
                    }
                    break;
                case 1:
                    {
                        if (dataGridGiroKeluar.SelectedCells.Count > 0)
                        {
                            Guid rowID = (Guid)dataGridGiroKeluar.SelectedCells[0].OwningRow.Cells["RowIDK"].Value;
                            DateTime TglJTGiro = (DateTime)dataGridGiroMasuk.SelectedCells[0].OwningRow.Cells["DueDateGiroK"].Value;

                            Keuangan.frmProsesGiroKeluarUpdate ifrmChild = new Keuangan.frmProsesGiroKeluarUpdate(this, rowID, TglJTGiro);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                        }
                    }
                    break;
                // case 2 kalau yang terbuka itu tab Giro Masuk Piutang Usaha
                case 2:
                    {
                        if (dataGridGiroMasukPiutang.SelectedCells.Count > 0)
                        {
                            Guid rowID = (Guid)dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["RowIDGMP"].Value;
                            String NoGiro = (String)dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["NoGiroGMP"].Value;
                            
                            
                            var penjualanRowID = new Guid();
                            //MessageBox.Show(dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["PenjualanRowIDGMP"].Value.ToString());
                            if (dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["PenjualanRowIDGMP"].Value.ToString() == null || dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["PenjualanRowIDGMP"].Value.ToString() == "")
                            {
                                penjualanRowID = (Guid) Guid.Empty;
                            }
                            else
                            {
                                penjualanRowID = (Guid)dataGridGiroMasukPiutang.SelectedCells[0].OwningRow.Cells["PenjualanRowIDGMP"].Value;
                            }

                            Keuangan.frmProsesGiroMasukPiutangUpdate ifrmChild = new Keuangan.frmProsesGiroMasukPiutangUpdate(this, rowID, NoGiro, penjualanRowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                        }
                    }
                    break;
            }
        }

        private void cmdSearchGiroMasuk_Click(object sender, EventArgs e)
        {
            RefreshGridMasuk();
        }

        private void cmdSearchGiroKeluar_Click(object sender, EventArgs e)
        {
            RefreshGridKeluar();
        }

        private void cmdSearchGiroMasukPiutang_Click(object sender, EventArgs e)
        {
            RefreshGridMasukPiutang();
        }

        // khusus ngeformat kolom status giro biar jadi teks angka statusnya
        private void dataGridGiroMasuk_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridGiroMasuk.Columns[e.ColumnIndex].Name == "StatusGiro")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "Diterima";
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Disetor";
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Batal Setor";
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "Cair";
                    }
                    else if (e.Value.ToString() == "4")
                    {
                        e.Value = "Batal Cair";
                    }
                    else if (e.Value.ToString() == "5")
                    {
                        e.Value = "Ditolak";
                    }
                    else if (e.Value.ToString() == "6")
                    {
                        e.Value = "Batal";
                    } 

                }
                e.FormattingApplied = true;
            }
        }

        private void frmProsesGiroBrowse_Activated(object sender, EventArgs e)
        {
            RefreshGridMasuk();
            RefreshGridKeluar();
            RefreshGridMasukPiutang();
        }

        private void dataGridGiroMasukPiutang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridGiroMasukPiutang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridGiroMasukPiutang.Columns[e.ColumnIndex].Name == "StatusGiroGMP")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "Diterima";
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Disetor";
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Batal Setor";
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "Cair";
                    }
                    else if (e.Value.ToString() == "4")
                    {
                        e.Value = "Batal Cair";
                    }
                    else if (e.Value.ToString() == "5")
                    {
                        e.Value = "Ditolak";
                    }
                    else if (e.Value.ToString() == "6")
                    {
                        e.Value = "Batal";
                    }

                }
                e.FormattingApplied = true;
            }
        }


    }
}
