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
using System.Globalization;
using ISA.Pin;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmKasOpnameUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.NewGuid();
        string mode = "NEW";
        FillComboBox fcbo = new Class.FillComboBox();
        double zero = 0;

        public frmKasOpnameUpdate(Form Caller)
        {
            InitializeComponent();
            this.Caller = Caller;
            mode = "NEW";
        }

        public frmKasOpnameUpdate(Form Caller, Guid RowID)
        {
            InitializeComponent();
            this.Caller = Caller;
            mode = "UPDATE";
            _rowID = RowID;
        }

        private void frmKasOpnameUpdate_Load(object sender, EventArgs e)
        {
            if(mode == "NEW")
            {
                dateTextBox1.DateValue = GlobalVar.GetServerDate;
                fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                if (cboKas.Items.Count > 1)
                {
                    cboKas.SelectedIndex = 1;
                }
                else if (cboKas.Items.Count > 0)
                {
                    cboKas.SelectedIndex =0;
                }

                txt100000.Text = zero.ToString("N2");
                txt50000.Text = zero.ToString("N2");
                txt20000.Text = zero.ToString("N2");
                txt10000.Text = zero.ToString("N2");
                txt5000.Text = zero.ToString("N2");
                txt2000.Text = zero.ToString("N2");
                txt1000.Text = zero.ToString("N2");
                txt500.Text = zero.ToString("N2");
                txt200.Text = zero.ToString("N2");
                txt100.Text = zero.ToString("N2");
                txt50.Text = zero.ToString("N2");
                txt25.Text = zero.ToString("N2");

                sum100000.Text = zero.ToString("N2");
                sum50000.Text = zero.ToString("N2");
                sum20000.Text = zero.ToString("N2");
                sum10000.Text = zero.ToString("N2");
                sum5000.Text = zero.ToString("N2");
                sum2000.Text = zero.ToString("N2");
                sum1000.Text = zero.ToString("N2");
                sum500.Text = zero.ToString("N2");
                sum200.Text = zero.ToString("N2");
                sum100.Text = zero.ToString("N2");
                sum50.Text = zero.ToString("N2");
                sum25.Text = zero.ToString("N2");
                lblsum.Text = zero.ToString("N2");
            }
            else if (mode == "UPDATE")
            {
                DataTable dt = new DataTable();
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if(dt.Rows.Count > 0)
                {
                    dateTextBox1.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"], GlobalVar.GetServerDate.Date));
                    fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                    txt100000.Text  = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p100000"], 0)).ToString();
                    txt50000.Text   = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p50000"], 0)).ToString();
                    txt20000.Text   = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p20000"], 0)).ToString();
                    txt10000.Text   = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p10000"], 0)).ToString();
                    txt5000.Text    = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p5000"], 0)).ToString();
                    txt2000.Text    = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p2000"], 0)).ToString();
                    txt1000.Text    = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p1000"], 0)).ToString();
                    txt500.Text     = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p500"], 0)).ToString();
                    txt200.Text     = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p200"], 0)).ToString();
                    txt100.Text     = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p100"], 0)).ToString();
                    txt50.Text      = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p50"], 0)).ToString();
                    txt25.Text      = Convert.ToDouble(Tools.isNull(dt.Rows[0]["p25"], 0)).ToString();

                    Double tempSum = recalculateALL();
                    Double fromDB = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Nominal"], 0));
                    lblsum.Text = tempSum.ToString("N2");
                }
            }
            else
            {
                MessageBox.Show("No mode selected, aborting!");
                this.Close();
            }

        }

        private double recalculateALL()
        {
            Double tempSum = 0;
            //100rb
            if (txt100000.GetDoubleValue > 0)
            {
                sum100000.Text = (txt100000.GetDoubleValue * 100000).ToString("N2");
                tempSum = tempSum + (txt100000.GetDoubleValue * 100000);
            }
            else
            {
                sum100000.Text = zero.ToString("N2");
            }
            //50rb
            if (txt50000.GetDoubleValue > 0)
            {
                sum50000.Text = (txt50000.GetDoubleValue * 50000).ToString("N2");
                tempSum = tempSum + (txt50000.GetDoubleValue * 50000);
            }
            else
            {
                sum50000.Text = zero.ToString("N2");
            }
            //20rb
            if (txt20000.GetDoubleValue > 0)
            {
                sum20000.Text = (txt20000.GetDoubleValue * 20000).ToString("N2");
                tempSum = tempSum + (txt20000.GetDoubleValue * 20000);
            }
            else
            {
                sum20000.Text = zero.ToString("N2");
            }
            //10rb
            if (txt10000.GetDoubleValue > 0)
            {
                sum10000.Text = (txt10000.GetDoubleValue * 10000).ToString("N2");
                tempSum = tempSum + (txt10000.GetDoubleValue * 10000);
            }
            else
            {
                sum10000.Text = zero.ToString("N2");
            }
            //5rb
            if (txt5000.GetDoubleValue > 0)
            {
                sum5000.Text = (txt5000.GetDoubleValue * 5000).ToString("N2");
                tempSum = tempSum + (txt5000.GetDoubleValue * 5000);
            }
            else
            {
                sum5000.Text = zero.ToString("N2");
            }
            //2rb
            if (txt2000.GetDoubleValue > 0)
            {
                sum2000.Text = (txt2000.GetDoubleValue * 2000).ToString("N2");
                tempSum = tempSum + (txt2000.GetDoubleValue * 2000);
            }
            else
            {
                sum2000.Text = zero.ToString("N2");
            }
            //1rb
            if (txt1000.GetDoubleValue > 0)
            {
                sum1000.Text = (txt1000.GetDoubleValue * 1000).ToString("N2");
                tempSum = tempSum + (txt1000.GetDoubleValue * 1000);
            }
            else
            {
                sum1000.Text = zero.ToString("N2");
            }
            //5rt
            if (txt500.GetDoubleValue > 0)
            {
                sum500.Text = (txt500.GetDoubleValue * 500).ToString("N2");
                tempSum = tempSum + (txt500.GetDoubleValue * 500);
            }
            else
            {
                sum500.Text = zero.ToString("N2");
            }
            //2rt
            if (txt200.GetDoubleValue > 0)
            {
                sum200.Text = (txt200.GetDoubleValue * 200).ToString("N2");
                tempSum = tempSum + (txt200.GetDoubleValue * 200);
            }
            else
            {
                sum200.Text = zero.ToString("N2");
            }
            //1rt
            if (txt100.GetDoubleValue > 0)
            {
                sum100.Text = (txt100.GetDoubleValue * 100).ToString("N2");
                tempSum = tempSum + (txt100.GetDoubleValue * 100);
            }
            else
            {
                sum100.Text = zero.ToString("N2");
            }
            //50
            if (txt50.GetDoubleValue > 0)
            {
                sum50.Text = (txt50.GetDoubleValue * 50).ToString("N2");
                tempSum = tempSum + (txt50.GetDoubleValue * 50);
            }
            else
            {
                sum50.Text = zero.ToString("N2");
            }
            //25
            if (txt25.GetDoubleValue > 0)
            {
                sum25.Text = (txt25.GetDoubleValue * 25).ToString("N2");
                tempSum = tempSum + (txt25.GetDoubleValue * 25);
            }
            else
            {
                sum25.Text = zero.ToString("N2");
            }
            lblsum.Text = tempSum.ToString("N2");
            return tempSum;
        }

        private void txt100000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt50000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt20000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt10000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt5000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt2000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt1000_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt500_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt200_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt100_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt50_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private void txt25_Leave(object sender, EventArgs e)
        {
            recalculateALL();
        }

        private bool validateSave()
        {
            if (string.IsNullOrEmpty(cboKas.Text))
            {
                MessageBox.Show("Pilih data Kas terlebih dahulu!");
                return false;
            }
            if (dateTextBox1.DateValue == GlobalVar.GetServerDate.Date)
            {
            }
            else if (dateTextBox1.DateValue >= GlobalVar.GetServerDate.Date.AddDays(-2) && dateTextBox1.DateValue < GlobalVar.GetServerDate.Date)
            {
                // kalau mau save untuk hari sebelumnya, kena pin

                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang,
                                Convert.ToInt32(PinId.ModulId.KasOpnamePrevDay),
                                "Untuk melakukan kas opname sampai 2 hari sebelumnya perlu PIN!");

                    if (GlobalVar.pinResult == false) { return false; }
            }
            else
            {
                // selain itu, ngga boleh save
                MessageBox.Show("Kas Opname hanya bisa diproses untuk hari ini sampai H-2 (PIN) saja!");
                return false;
            }

            // cek ke database, kalau hari yg diproses pernah dikas opname, ngga boleh lagi! // hanya kalau baru saja, editan jangan!!!
            if (mode == "NEW")
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Sudah dilakukan KasOpname untuk tanggal inputan!");
                        return false;
                    }
                }
            }
            return true;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Double TempSum = recalculateALL();
            if (validateSave())
            {
                // db Finance
                Database db = new Database(); 
                try
                {
                    db.BeginTransaction();
                    if (mode == "NEW")
                    {
                        db.Commands.Add(db.CreateCommand("usp_KasOpname_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, TempSum));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@p100000", SqlDbType.Int, txt100000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p50000", SqlDbType.Int, txt50000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p20000", SqlDbType.Int, txt20000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p10000", SqlDbType.Int, txt10000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p5000", SqlDbType.Int, txt5000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p2000", SqlDbType.Int, txt2000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p1000", SqlDbType.Int, txt1000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p500", SqlDbType.Int, txt500.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p200", SqlDbType.Int, txt200.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p100", SqlDbType.Int, txt100.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p50", SqlDbType.Int, txt50.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p25", SqlDbType.Int, txt25.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    else if (mode == "UPDATE")
                    {
                        db.Commands.Add(db.CreateCommand("usp_KasOpname_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, TempSum));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@p100000", SqlDbType.Int, txt100000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p50000", SqlDbType.Int, txt50000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p20000", SqlDbType.Int, txt20000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p10000", SqlDbType.Int, txt10000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p5000", SqlDbType.Int, txt5000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p2000", SqlDbType.Int, txt2000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p1000", SqlDbType.Int, txt1000.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p500", SqlDbType.Int, txt500.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p200", SqlDbType.Int, txt200.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p100", SqlDbType.Int, txt100.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p50", SqlDbType.Int, txt50.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@p25", SqlDbType.Int, txt25.GetDoubleValue));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    MessageBox.Show("Data berhasil diproses!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    db.RollbackTransaction();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTextBox1_Enter(object sender, EventArgs e)
        {
            ISA.Controls.DateTextBox target = (ISA.Controls.DateTextBox)sender;
            ToolTip message = new ToolTip();
            message.Show("Tanggal hanya bisa diisikan Tanggal hari ini!", target, 0, 22, 2500);
        }

        private void dateTextBox1_Leave(object sender, EventArgs e)
        {
            if (dateTextBox1.DateValue == GlobalVar.GetServerDate.Date)
            {
            }
            else if (dateTextBox1.DateValue >= GlobalVar.GetServerDate.Date.AddDays(-2) && dateTextBox1.DateValue < GlobalVar.GetServerDate.Date)
            {
                ISA.Controls.DateTextBox target = (ISA.Controls.DateTextBox)sender;
                ToolTip message = new ToolTip();
                message.Show("Untuk mengisi data H-1, saat proses Save akan memerlukan PIN!", target, 0, 22, 2500);
            }
            else
            {
                MessageBox.Show("Data Tanggal tidak Valid! Hanya bisa mengisi Data Kas Opname untuk hari ini sampai H-2!");
                dateTextBox1.Focus();
            }
        }

        private void frmKasOpnameUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Keuangan.frmKasOpnameBrowse)
            {
                Keuangan.frmKasOpnameBrowse frmCaller = (Keuangan.frmKasOpnameBrowse)this.Caller;
                frmCaller.refreshData();
            }
        }



    }
}
