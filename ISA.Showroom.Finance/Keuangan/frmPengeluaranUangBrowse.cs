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
    public partial class frmPengeluaranUangBrowse : ISA.Controls.BaseForm
    {
        bool _isRealisasi = true;
        DateTime _fromDate, _toDate; 
         
        public frmPengeluaranUangBrowse()  
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1*(_toDate.Day-1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
        }

        public frmPengeluaranUangBrowse(bool isRealisasi)
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1 * (_toDate.Day - 1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
            _isRealisasi = isRealisasi;
        }

        private void frmPengeluaranUangBrowse_Load(object sender, EventArgs e)
        {
           RefreshData();
           this.Title = ((_isRealisasi) ? "" : "Pengajuan ") + "Pengeluaran Uang";
           dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //            cmdADD.Visible = !_isRealisasi;
           cmdKOREKSI.Visible = ((SecurityManager.BizRoles.Count > 0) && (SecurityManager.BizRoles[0].ToString() == "EDP"));
           if (GlobalVar.PerusahaanID != "PBR")
           {
               // dataGridView1.Columns["IdentifikasiPiutang"].Visible = false;
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
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@IsRealisasi", SqlDbType.TinyInt, _isRealisasi));
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


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgtglKlr.FromDate;
            _toDate = (DateTime)rgtglKlr.ToDate;
            RefreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, !_isRealisasi);
            //Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, "kjhkjh");
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].OwningRow.Cells["JnsTransaksi"].Value.ToString().Equals("PIUTANG LAIN LAIN"))
                {
                    return;
                }
                String KodeJnsTransaksi = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeJnsTransaksi"].Value.ToString().Trim();
                if (Tools.checkLockEditDelete(KodeJnsTransaksi)) // kalau dibalikin true, berarti iya dikunci
                {
                    MessageBox.Show("Data Pengeluaran ini tidak dapat diedit maupun didelete!");
                    return;
                }
                Guid JournalRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value, Guid.Empty).ToString());
                if (JournalRowID == null || JournalRowID == Guid.Empty) { }
                else
                {
                    MessageBox.Show("Data Pengeluaran ini sudah masuk ke Jurnal!");
                    return;
                }
                

                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, !_isRealisasi, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }



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

        private string ValidasiDelete()
        {
            string sresult = "Valid";
            DataRow dr = (DataRow)(dataGridView1.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            if ((Guid)Tools.isNull(dr["HIRowID"], Guid.Empty) != Guid.Empty) sresult = "Sudah diproses DKN";
            else if ((Guid)Tools.isNull(dr["JournalRowID"], Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal";
            {
                DateTime TglInput = (DateTime)dr["CreatedTime"];
                List<int> parameter = ParameterKuncian();
                if (TglInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TglInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Sudah lewat batas waktu pengeditan.";
            }
            return sresult;
        }


        #endregion


        private void HapusData()
        {
            try
            {

                bool IsGroup_ = (bool)this.dataGridView1.SelectedCells[0].OwningRow.Cells["IsGroup"].Value;

                //if (IsGroup_.Equals(false))
                //{
                    this.Cursor = Cursors.WaitCursor;
                    Guid RowID = (Guid)this.dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    RefreshData();
                //}
                //else
                //{
                //    MessageBox.Show("Maaf, Data pengeluaran uang tidak bisa dihapus.");
                //    return;
                //}


               
            }
            catch (Exception Ex) { Error.LogError(Ex); }
            finally { this.Cursor = Cursors.Default; }
            

        }



        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string _result = ValidasiDelete();
            if ( _result=="Valid")
            {
                if (dataGridView1.SelectedCells[0].OwningRow.Cells["JnsTransaksi"].Value.ToString().Equals("PIUTANG LAIN LAIN"))
                {
                    return;
                }

                String KodeJnsTransaksi = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeJnsTransaksi"].Value.ToString().Trim();
                if (Tools.checkLockEditDelete(KodeJnsTransaksi)) // kalau dibalikin true, berarti iya dikunci
                {
                    MessageBox.Show("Data Pengeluaran ini tidak dapat diedit maupun didelete!");
                    return;
                }

                HapusData();
            }
            else
            {
                MessageBox.Show("Maaf, proses delete sudah tidak bisa dilakukan," + Environment.NewLine + _result);
                return;
            }
        }

        private void cmdKOREKSI_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Keuangan.frmKoreksiKeuangan ifrmChild = new frmKoreksiKeuangan(RowID, "KK");
            ifrmChild.MdiParent = this.MdiParent;
            ifrmChild.Show();
        }


       

    }
}
