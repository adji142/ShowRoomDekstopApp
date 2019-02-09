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
    public partial class frmCF_RencanaPembayaranHI : ISA.Controls.BaseForm
    {
        List<TextBox> _lTxtJumlah = new List<TextBox>();
        Guid _RowID;

        public frmCF_RencanaPembayaranHI()
        {
            InitializeComponent();
            myPeriode.Month = GlobalVar.GetServerDate.Month;
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
                db.Commands.Add(db.CreateCommand("usp_Cabang_LIST_FILTER_PT"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgCabang.DataSource = dt;
            }
        }
        private void RefreshData()
        {
            lblJudul.Text = myPeriode.MonthName.ToUpper() + "-" + myPeriode.Year.ToString().ToUpper();
            SetEnableDisable();
            string CabangID = "";
            if (dgCabang.SelectedCells.Count > 0)
            {
                CabangID = dgCabang.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
            }
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranHI_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
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

        private void frmCF_RencanaPembayaranHI_Load(object sender, EventArgs e)
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

        private void dgCabang_SelectionChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            string CabangID = dgCabang.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
            string Periode = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2, '0');
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranHI_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                for (int i = 0; i <= _lTxtJumlah.Count - 1; i++)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@d" + Convert.ToString(i + 1), SqlDbType.Money, _lTxtJumlah[i].Text));
                }
                db.Commands[0].ExecuteNonQuery();
            }
            RefreshData();

        }
    }
}
