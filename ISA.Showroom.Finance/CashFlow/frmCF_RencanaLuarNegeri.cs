﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmCF_RencanaLuarNegeri : ISA.Controls.BaseForm
    {
        List<TextBox> _lTxtJumlah = new List<TextBox>();
        Guid _RowID;
        enum enumBrow { Header, Detail };
        enum enumModus { Clear, New, Update };
        enumBrow Brow;
        enumModus Modus;

        public frmCF_RencanaLuarNegeri()
        {
            InitializeComponent();
            myPeriode.Month = GlobalVar.GetServerDate.Month;
            myPeriode.Year = GlobalVar.GetServerDate.Year;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Functions
        private void InitControl()
        {
            _lTxtJumlah.Add(n1);
            _lTxtJumlah.Add(n2);
            _lTxtJumlah.Add(n3);
            _lTxtJumlah.Add(n4);
            _lTxtJumlah.Add(n5);
            _lTxtJumlah.Add(n6);
            _lTxtJumlah.Add(n7);
            _lTxtJumlah.Add(n8);
            _lTxtJumlah.Add(n9);
            _lTxtJumlah.Add(n10);
            _lTxtJumlah.Add(n11);
            _lTxtJumlah.Add(n12);
            _lTxtJumlah.Add(n13);
            _lTxtJumlah.Add(n14);
            _lTxtJumlah.Add(n15);
            _lTxtJumlah.Add(n16);
            _lTxtJumlah.Add(n17);
            _lTxtJumlah.Add(n18);
            _lTxtJumlah.Add(n19);
            _lTxtJumlah.Add(n20);
            _lTxtJumlah.Add(n21);
            _lTxtJumlah.Add(n22);
            _lTxtJumlah.Add(n23);
            _lTxtJumlah.Add(n24);
            _lTxtJumlah.Add(n25);
            _lTxtJumlah.Add(n26);
            _lTxtJumlah.Add(n27);
            _lTxtJumlah.Add(n28);
            _lTxtJumlah.Add(n29);
            _lTxtJumlah.Add(n30);
            _lTxtJumlah.Add(n31);
        }
        private void SetEnableDisable()
        {
            for (int i = 0; i <= _lTxtJumlah.Count - 1; i++)
            {
                _lTxtJumlah[i].Enabled = noMonday(i + 1);
            }
            cmdADD.Enabled = Brow == enumBrow.Detail && Modus == enumModus.Clear;
            cmdEDIT.Enabled = Brow == enumBrow.Detail && Modus == enumModus.Clear && dgDetail.SelectedCells.Count > 0;
            cmdDELETE.Enabled = Brow == enumBrow.Detail && Modus == enumModus.Clear && dgDetail.SelectedCells.Count > 0;
            cmdSAVE.Enabled = Modus == enumModus.Clear;
        }
        private bool noMonday(int tgl)
        {
            string tahun = myPeriode.Year.ToString().PadLeft(4, '0');
            string bulan = myPeriode.Month.ToString().PadLeft(2, '0');
            string tanggal = tgl.ToString().PadLeft(2, '0');
            int LastDay = Convert.ToDateTime(tahun + "-" + bulan + "-01").AddMonths(1).AddDays(-1).Day;
            if (tgl > LastDay) return false;
            DateTime dTanggal = Convert.ToDateTime(tahun + "-" + bulan + "-" + tanggal);
            return dTanggal.DayOfWeek != DayOfWeek.Sunday;
        }
        private void RefreshDataGrid()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                dgVendor.DataSource = dt;
            }
        }
        private void RefreshDataGridDetail()
        {
            if (dgVendor.SelectedCells.Count > 0)
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, dgVendor.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgDetail.DataSource = dt;
                }
            }
        }
        private void RefreshData()
        {
            lblJudul.Text = myPeriode.MonthName.ToUpper() + "-" + myPeriode.Year.ToString().ToUpper();
            SetEnableDisable();
            Guid VendorRowID = (Guid)Guid.Empty;
            Guid VendorDetailRowID = (Guid)Guid.Empty;
            if (dgVendor.SelectedCells.Count > 0) VendorRowID = (Guid)dgVendor.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            if (dgDetail.SelectedCells.Count > 0) VendorDetailRowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaLuarNegeri_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID));
                if (VendorDetailRowID != (Guid)Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@VendorDetailRowID", SqlDbType.UniqueIdentifier, VendorDetailRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                _RowID = (Guid)dr["RowID"];
                for (int i = 0; i <= _lTxtJumlah.Count - 1; i++)
                {
                    _lTxtJumlah[i].Text = dr["d" + (i + 1).ToString()].ToString();
                }
            }
            else
            {
                _RowID = Guid.Empty;
                for (int i = 0; i <= _lTxtJumlah.Count - 1; i++)
                {
                    _lTxtJumlah[i].Text = "0";
                }
            }
        }
        private void RefreshDataUpdate()
        {
            if (dgVendor.SelectedCells.Count > 0)
            {
                if (Modus == enumModus.Update)
                {
                    dateBukti.DateValue = Convert.ToDateTime(dgDetail.SelectedCells[0].OwningRow.Cells["TglBukti"].Value);
                    textNoBukti.Text = dgDetail.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                    dateTempo.DateValue = Convert.ToDateTime(dgDetail.SelectedCells[0].OwningRow.Cells["TglTempo"].Value);
                    textAmount.Text = dgDetail.SelectedCells[0].OwningRow.Cells["Amount"].Value.ToString();
                    textKurs.Text = dgDetail.SelectedCells[0].OwningRow.Cells["Kurs"].Value.ToString();
                }
                else
                {
                    dateBukti.DateValue = GlobalVar.GetServerDate;
                    textNoBukti.Text = "";
                    dateTempo.DateValue = GlobalVar.GetServerDate;
                    textAmount.Text = "0";
                    textKurs.Text = "0";
                }
                dateBukti.Focus();
            }
        }
        #endregion

        private void frmCF_RencanaLuarNegeri_Load(object sender, EventArgs e)
        {
            InitControl();
            SetEnableDisable();
            RefreshDataGrid();
            RefreshData();
            Modus = enumModus.Clear;
        }

        private void myPeriode_Leave(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Guid VendorRowID = (Guid)dgVendor.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            if (dgDetail.SelectedCells.Count > 0)
            {
                VendorRowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
            }
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaLuarNegeri_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                for (int i = 0; i <= _lTxtJumlah.Count - 1; i++)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@d" + Convert.ToString(i + 1), SqlDbType.Money, _lTxtJumlah[i].Text));
                }
                db.Commands[0].ExecuteNonQuery();
            }
            RefreshData();
        }

        private void dgVendor_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataGridDetail();
        }

        private void cmdSAVED_Click(object sender, EventArgs e)
        {
            Double Nominal = Convert.ToDouble(textAmount.Text) * Convert.ToDouble(textKurs.Text);
            int Tgl = dateTempo.DateValue.Value.Day;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranDetail_UPDATE"));
                if (Modus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dgDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value));
                else db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, dgVendor.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                db.Commands[0].Parameters.Add(new Parameter("@TglBukti", SqlDbType.Date, dateBukti.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, textNoBukti.Text.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@TglTempo", SqlDbType.Date, dateTempo.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@Amount", SqlDbType.Money, Convert.ToDouble(textAmount.Text)));
                db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Money, Convert.ToDouble(textKurs.Text)));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                db.Commands[0].ExecuteNonQuery();
            }
            dgDetail.Focus();
            panelUPDATE.Visible = false;
            Modus = enumModus.Clear;
            SetEnableDisable();
            RefreshDataGridDetail();
            dgDetail.FindRow("NoBukti", textNoBukti.Text.ToString());
            _lTxtJumlah[Tgl-1].Text = Nominal.ToString();
            cmdSAVE_Click(sender, e);
        }

        private void cmdCLOSED_Click(object sender, EventArgs e)
        {
            dgDetail.Focus();
            panelUPDATE.Visible = false;
            Modus = enumModus.Clear;
            SetEnableDisable();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            panelUPDATE.Visible = true;
            Modus = enumModus.New;
            SetEnableDisable();
            RefreshDataUpdate();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            panelUPDATE.Visible = true;
            Modus = enumModus.Update;
            SetEnableDisable();
            RefreshDataUpdate();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus detail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranDetail_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dgDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshDataGridDetail();
            }
        }

        private void dgVendor_Enter(object sender, EventArgs e)
        {
            Brow = enumBrow.Header;
            SetEnableDisable();
        }

        private void dgDetail_Enter(object sender, EventArgs e)
        {
            Brow = enumBrow.Detail;
            SetEnableDisable();
        }

        private void panelUPDATE_Leave(object sender, EventArgs e)
        {
            panelUPDATE.Visible = false;
            Modus = enumModus.Clear;
            SetEnableDisable();
        }

        private void dgDetail_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
