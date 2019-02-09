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
    public partial class frmPenerimaanUangBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate , _toDate;


        public frmPenerimaanUangBrowse()
        {
            InitializeComponent();
            cmdKOREKSI.Visible = ((SecurityManager.BizRoles.Count>0) && (SecurityManager.BizRoles[0].ToString() == "EDP"));
        } 

        private void frmUangMasukBrowse_Load(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID != "PBR")
            {
                // dataGridView1.Columns["IdentifikasiPiutang"].Visible = false;
            }
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(1 - _toDate.Day);
            rgtglTrm.FromDate = _fromDate;
            rgtglTrm.ToDate = _toDate;
            LoadComboStatusTransaksi();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; 
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        #region Load combo status transaksi

        private void LoadComboStatusTransaksi()
        {
           
            DataListByNoBukti();
            cboStatusTransaksi.Items.Add("Semua");
            cboStatusTransaksi.Items.Add("Terealisasi");
            cboStatusTransaksi.SelectedIndex = 1;
        }

        #endregion


        private void cmdADD_Click(object sender, EventArgs e)
        {
            Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this);
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
                    MessageBox.Show("Data Penerimaan ini tidak dapat diedit maupun didelete!");
                    return;
                }
                Guid JournalRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value, Guid.Empty).ToString());
                if (JournalRowID == null || JournalRowID == Guid.Empty) { }
                else
                {
                    MessageBox.Show("Data Penerimaan ini sudah masuk ke Jurnal!");
                    return;
                }
                try
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                   
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_ChekGiro]"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
               
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (ValidasiDelete() != "Valid")
            {
                MessageBox.Show("Maaf, proses delete sudah tidak bisa dilakukan," + Environment.NewLine + "karena sudah di luar dari batas waktu yang ditentukan.");
                return;
            }
            else if (dataGridView1.Rows.Count > 0 && (Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["KodeJnsTransaksi"].Value, "")).ToString() == "110")
            {
                MessageBox.Show("Tidak boleh menghapus data dari jns transasksi : PIUTANG LSG BLM IDEN");
                return;
            }
            else
            {
                if (dataGridView1.SelectedCells[0].OwningRow.Cells["JnsTransaksi"].Value.ToString().Equals("PIUTANG LAIN LAIN"))
                {
                    return;
                }
                String KodeJnsTransaksi = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeJnsTransaksi"].Value.ToString().Trim();
                if (Tools.checkLockEditDelete(KodeJnsTransaksi)) // kalau dibalikin true, berarti iya dikunci
                {
                    MessageBox.Show("Data Penerimaan ini tidak dapat diedit maupun didelete!");
                    return;
                }
                deleteData();
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
                DateTime TanggalInput = (DateTime)this.dataGridView1.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
                //bool Expired = false;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }
            return sresult;
        }


        #endregion


        private void deleteData()
        {

            bool IsGroup_ = (bool)this.dataGridView1.SelectedCells[0].OwningRow.Cells["IsGroup"].Value;


            if (IsGroup_.Equals(false))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    if (MessageBox.Show("Hapus cabang id: " + dataGridView1.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString()
                                        + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }

                            MessageBox.Show("Record telah dihapus");
                            this.RefreshData();
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
            else
            {
                
                MessageBox.Show("Maaf, Data penerimaan uang tidak bisa dihapus.");
                return;
            }

            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteData();
            }
        }


        #region sort by no bukti

        private void DataListByNoBukti()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_Realisasi_FILTER_Tanggal"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, _fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, _toDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
       
        }

        #endregion

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgtglTrm.FromDate;
            _toDate = (DateTime)rgtglTrm.ToDate;
            if (cboStatusTransaksi.SelectedIndex == 0)
            {
                RefreshData();
            }
            else
            {
                DataListByNoBukti();
            }
        }

        private void cmdKOREKSI_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Keuangan.frmKoreksiKeuangan ifrmChild = new frmKoreksiKeuangan(RowID,"KM");
            ifrmChild.MdiParent = this.MdiParent;
            ifrmChild.Show();
        }

      

    }
    }

