using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmCF_RealisasiLuarNegeri : ISA.Controls.BaseForm
    {
        List<TextBox> _lTxtJumlah = new List<TextBox>();
        Guid _RowID;

        public frmCF_RealisasiLuarNegeri()
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
                _lTxtJumlah[i].ReadOnly = true ; ;
            }
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
            if (dgVendor.SelectedCells.Count > 0)
            {
                VendorRowID = (Guid)dgVendor.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            }
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RealisasiLuarNegeri_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID));
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
        #endregion

        private void frmCF_RealisasiLuarNegeri_Load(object sender, EventArgs e)
        {
            InitControl();
            SetEnableDisable();
            RefreshDataGrid();
            RefreshData();
        }

        private void myPeriode_Leave(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgVendor_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataGridDetail();
        }

        private void cmdREFRESH_Click(object sender, EventArgs e)
        {
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RealisasiLuarNegeri_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            RefreshData();
        }

    }
}
