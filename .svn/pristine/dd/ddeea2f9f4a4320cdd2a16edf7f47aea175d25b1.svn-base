using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmAdjPiutang : ISA.Controls.BaseForm
    {
        Guid _rowidP;

        public frmAdjPiutang()
        {
            InitializeComponent();
        }

        public frmAdjPiutang(Form caller, Guid rowid, string notrans, string customer, string sales, double saldo, double sisa, DateTime tglTrans, double nominalbataliden)
        {
            InitializeComponent();
            _rowidP=rowid;
            txtNoTr.Text=notrans;
            txtCustomer.Text=customer;
            txtSales.Text=sales;
            txtTglTr.DateValue=tglTrans;
            txtSaldoPiutang.Text=saldo.ToString();
            txtNominalSisa.Text = sisa.ToString();
            txtNominal.Text = nominalbataliden.ToString();
            if (nominalbataliden != 0)
            {
                txtNominal.ReadOnly = true;
            }
            this.Caller = caller;
        }

        private void frmAdjPiutang_Load(object sender, EventArgs e)
        {
            txtTglAdj.DateValue = DateTime.Now;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtNominal.Text) == 0)
            {
                MessageBox.Show("Nominal harus >=0");
                txtNominal.Focus();
                return;
            }

            if (Double.Parse(txtNominal.Text) > Double.Parse(txtNominalSisa.Text))
            {
                MessageBox.Show("Sisa Nominal hanya " + txtNominalSisa.Text);
                txtNominal.Focus();
                return;
            }

            if (txtUraian.Text == "")
            {
                MessageBox.Show("Uraian harus di isi.");
                txtUraian.Focus();
                return;
            }

            try
            {
                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/BKM/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                Guid _rowID = Guid.NewGuid();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUM_INSERT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowidP));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransPenerimaan));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ADJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglAdj.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, "IDR"));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Double.Parse(txtNominal.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                if (this.Caller is Kasir.frmPenerimaanLeasingBrowse)
                {
                    Kasir.frmPenerimaanLeasingBrowse frmCaller = (Kasir.frmPenerimaanLeasingBrowse)this.Caller;
                    frmCaller.RefreshHeader3(_rowidP.ToString());
                    frmCaller.RefreshDetail(Guid.Empty);
                }
                this.Close();
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
