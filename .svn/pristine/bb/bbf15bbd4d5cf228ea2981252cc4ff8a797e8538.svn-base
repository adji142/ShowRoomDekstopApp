using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.DKN
{
    public partial class frmPembebananCabang_subdetail : ISA.Controls.BaseForm
    {
        Guid _HeaderRowID,_JenisTransaksi;
        string _Uraian;
        enum enumFormMode {New, Update};
        enumFormMode formMode;
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        public frmPembebananCabang_subdetail(Guid HeaderRowID,string NamaBeban,string CabangID,string NamaPT,int TiapTanggal,Guid JenisTransaksi,string Uraian)
        {
            InitializeComponent();
            fcbo.fillComboCabang(cboCabang);
            fcbo.fillComboPerusahaan(cboPT);
            fcbo.fillComboKelompokHI(cboTransaksi);
            _HeaderRowID = HeaderRowID;
            txtNamaBeban.Text = NamaBeban;
            cboCabang.SelectedValue = CabangID;
            cboPT.Text = NamaPT;
            cboTransaksi.SelectedValue = JenisTransaksi;
            numTiapTanggal.Text = TiapTanggal.ToString();
            panel1.Enabled = false;
            _JenisTransaksi = JenisTransaksi;
            _Uraian = Uraian;
        }

        private void commandButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPembebananCabang_subdetail_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            RefreshData();
            RefreshButton(false);
        }

        private void RefreshGrid()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PembebananCabangSubDetail_LIST_BY_HeaderRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgSubDetail.DataSource = dt;
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            numericTextBox1.Text = "0";
            formMode = enumFormMode.New;
            RefreshButton(true);
            monthYearBox1.Focus();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            formMode = enumFormMode.Update;
            RefreshButton(true);
            monthYearBox1.Focus();
        }

        private void RefreshData()
        {
            if (dgSubDetail.Rows.Count > 0)
            {
                monthYearBox1.Month = Convert.ToInt16(dgSubDetail.SelectedCells[0].OwningRow.Cells["Bulan"].Value);
                monthYearBox1.Year = Convert.ToInt16(dgSubDetail.SelectedCells[0].OwningRow.Cells["Tahun"].Value);
                numericTextBox1.Text = Convert.ToString(dgSubDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value);
            }
        }

        private void RefreshButton(Boolean TF)
        {
            commandButton1.Enabled = !TF;
            commandButton2.Enabled = !TF && dgSubDetail.Rows.Count > 0;
            commandButton3.Enabled = !TF && dgSubDetail.Rows.Count > 0;
            commandButton4.Enabled = TF;
            commandButton5.Enabled = TF;
            cmdLINK.Enabled = false;
            if (dgSubDetail.SelectedCells.Count > 0)
            {
                cmdLINK.Enabled = !TF && Convert.ToBoolean(dgSubDetail.SelectedCells[0].OwningRow.Cells["IsLink"].Value) == false;
            }
            panel1.Enabled = TF;
        }
        private void commandButton4_Click(object sender, EventArgs e)
        {
            string _Tahun = monthYearBox1.Year.ToString();
            string _Bulan = monthYearBox1.Month.ToString();
            if (_Bulan.Length == 1) _Bulan = "0" + _Bulan;
            if (Convert.ToDouble(numericTextBox1.Text) > 0)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (formMode == enumFormMode.New)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabangSubDetail_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, numericTextBox1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, _Tahun + _Bulan));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, dateTransaksi.DateValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    else
                    {
                        Guid _RowID = (Guid)dgSubDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabangSubDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, numericTextBox1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, _Tahun + _Bulan));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, dateTransaksi.DateValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            RefreshGrid();
            RefreshData();
            RefreshButton(false);
            dgSubDetail.Focus();
        }

        private void commandButton5_Click(object sender, EventArgs e)
        {
            RefreshData();
            RefreshButton(false);
            dgSubDetail.Focus();
        }

        private void dgSubDetail_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgSubDetail_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshData();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data ini?", "Hapus data", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Guid RowID = (Guid)dgSubDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PembebananCabangSubDetail_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshGrid();
                RefreshData();
            }

        }

        private void dateTransaksi_Enter(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                string _Tahun = monthYearBox1.Year.ToString();
                string _Bulan = monthYearBox1.Month.ToString();
                string _Tanggal = numTiapTanggal.Text.ToString();
                if (_Bulan.Length == 1) _Bulan = "0" + _Bulan;
                if (_Tanggal.Length == 1) _Tanggal = "0" + _Tanggal;
                dateTransaksi.DateValue = Convert.ToDateTime(_Tahun + "-" + _Bulan + "-" + _Tanggal);
            }
        }

        private void cmdLINK_Click(object sender, EventArgs e)
        {
            if ((bool)dgSubDetail.SelectedCells[0].OwningRow.Cells["IsLink"].Value == false)
            {
                Guid RowID = (Guid)dgSubDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid PerusahaanKeRowID = GlobalVar.PerusahaanRowID;
                string RecordID = GlobalVar.PerusahaanID + GlobalVar.GetServerDate.Year.ToString() + GlobalVar.GetServerDate.Month.ToString() + GlobalVar.GetServerDate.Day.ToString() + GlobalVar.GetServerDate.TimeOfDay.ToString().Substring(0, 8) + SecurityManager.UserInitial;
                string CabangKeID = "11";
                DateTime Tanggal = (DateTime)dgSubDetail.SelectedCells[0].OwningRow.Cells["TglTransaksi"].Value;
                if (cboCabang.Text != "") CabangKeID = cboCabang.SelectedValue.ToString();
                if (cboPT.Text != "") PerusahaanKeRowID = (Guid)cboPT.SelectedValue;
                Double Nominal = Convert.ToDouble(dgSubDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, Tanggal));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.TinyInt, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PerusahaanKeRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, "11"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, CabangKeID));
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID", SqlDbType.UniqueIdentifier, _JenisTransaksi));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                    
                    db.Commands.Clear();

                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _Uraian));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
                    db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Nominal));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "BEBANCAB_SMNL"));
                    db.Commands[0].ExecuteNonQuery();

                    db.Commands.Clear();

                    db.Commands.Add(db.CreateCommand("usp_PembebananCabang_UPDATE_LINKED"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshGrid();
                RefreshData();
                RefreshButton(false);
            }
        }
    }
}
