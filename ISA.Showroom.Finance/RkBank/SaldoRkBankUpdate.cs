using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.RkBank
{
    public partial class SaldoRkBankUpdate : ISA.Controls.BaseForm 
    {
        public Guid _RowID, _RekeningRowID;
        public String _matauangID;
        public string _Modus;

        public SaldoRkBankUpdate()
        {
            InitializeComponent();
        }
        public SaldoRkBankUpdate(Form Caller, Guid RekeningRowID,String MataUangID)
        {
            InitializeComponent();
            _Modus = "Tambah";
            _matauangID = MataUangID;
            _RekeningRowID = RekeningRowID;
            txtTanggal.DateValue = GlobalVar.GetServerDate;
        }
        public SaldoRkBankUpdate(Form Caller, Guid RekeningRowID, Guid RowID, String MataUangID)
        {
            InitializeComponent();
            _Modus = "Edit";
            _matauangID = MataUangID;
            _RowID = RowID;
            
            _RekeningRowID = RekeningRowID;
            LoadEdit();
        }



        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                Double NominalIDR = 0;
                Double Kurs = 0;
                DataTable dt = new DataTable();
                if (_matauangID == "USD")
                {


                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetKursMataUangIDR_LAST"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKurs", SqlDbType.Date, txtTanggal.DateValue));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count > 0)
                    {

                        Kurs = (Double)dt.Rows[0]["Kurs"];
                        NominalIDR = txtJumlah.GetDoubleValue * Kurs;
                    }


                    else
                    {
                        MessageBox.Show("Nilai Kurs tanggal " + txtTanggal.Text + " belum di update!" + Environment.NewLine + "silakan update Nilai kurs pada tanggal " + txtTanggal.Text + ".");
                        return;
                    }

                }
                else { NominalIDR = txtJumlah.GetDoubleValue; }




                using (Database db = new Database())
                {
                    if (_Modus == "Tambah")
                    {
                        db.Commands.Add(db.CreateCommand("usp_SaldoRkBank_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, _RekeningRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTanggal.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtJumlah.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalIDR", SqlDbType.Money, NominalIDR));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_SaldoRkBank_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTanggal.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtJumlah.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalIDR", SqlDbType.Money, NominalIDR));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Close();
            }
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Functions
        private void LoadEdit()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SaldoRkBank_SEEK"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID ));
                dt = db.Commands[0].ExecuteDataTable();
            }
            txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalRk"], "");
            txtJumlah.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
        }
        #endregion

        private void SaldoRkBankUpdate_Load(object sender, EventArgs e)
        {
            lblMataUangID.Text = _matauangID;
        }

     
    }
}
