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
using System.Data.SqlTypes;

namespace ISA.Showroom.Pembelian
{
    public partial class frmTglTerimaUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty; // rowID pembelian

        public frmTglTerimaUpdate()
        {
            InitializeComponent();
        }

        public frmTglTerimaUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            Caller = caller;
            _rowID = rowID;
        }


        #region Parameter Lock

        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
                _parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);

            }
            return _parameterkuncian;
        }

        private bool ValidasiSimpan()
        {
            bool valid = true;
            List<int> parameter = ParameterKuncian();
            // misal 9 sept, maka bisanya hanya 9, 8, 7 Sept
            if (txtTglTerima.DateValue > GlobalVar.GetServerDate
                 ||
                 txtTglTerima.DateValue < GlobalVar.GetServerDate.AddDays(-parameter[0])
               )
            { valid = true; }//false; }
            return valid;
        }


        #endregion

        private void frmTglTerimaUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST_TglTerima"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if ((DateTime)Tools.isNull(dt.Rows[0]["TglTerima"], DateTime.MaxValue) == DateTime.MaxValue)
                    {
                        txtTglTerima.Text = "";
                    }
                    else
                    {
                        txtTglTerima.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TglTerima"], null);
                    }
                    // txtTglTerima.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["TglTerima"], GlobalVar.GetServerDate));
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool result;
            DateTime tempdummy;
            List<int> parameter = ParameterKuncian();
            result = DateTime.TryParse(txtTglTerima.DateValue.ToString(), out tempdummy);
            if (result == false || String.IsNullOrEmpty(txtTglTerima.Text) )
            {
                MessageBox.Show("Data Tanggal Terima tidak valid, silahkan periksa kembali.");
                return;
            }
            result = ValidasiSimpan();
            if (result == false)
            {
                MessageBox.Show("Data Tanggal Terima tidak valid, batasan pengisian adalah hari ini sampai -" + parameter[0].ToString() + " hari dari hari ini.");
                return;
            }

            if(result == true)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_UPDATE_TglTerima"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.Date, tempdummy));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
        }

        private void txtTglTerima_Enter(object sender, EventArgs e)
        {
            TextBox target = (TextBox)sender;
            ToolTip message = new ToolTip();
            message.Show("dd/mm/yyyy | ex. 31/12/1990", target, 0, 22, 2500);
        }
    }
}
