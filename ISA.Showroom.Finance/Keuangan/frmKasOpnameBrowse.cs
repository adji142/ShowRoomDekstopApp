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
    public partial class frmKasOpnameBrowse : ISA.Controls.BaseForm
    {
        public frmKasOpnameBrowse()
        {
            InitializeComponent();
        }

        private void frmKasOpnameBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refreshData()
        {
            if (rangeDateBox1.FromDate > rangeDateBox1.ToDate)
            {
                DateTime temp = rangeDateBox1.ToDate.Value;
                rangeDateBox1.ToDate = rangeDateBox1.FromDate;
                rangeDateBox1.FromDate = temp;
            }

            if (rangeDateBox1.FromDate.HasValue == false || rangeDateBox1.ToDate.HasValue == false)
            {
                MessageBox.Show("Isikan tanggal terlebih dahulu!");
                rangeDateBox1.Focus();
                return;
            }

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
                dgKasOpname.DataSource = dt;
            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            {
                Keuangan.frmKasOpnameUpdate ifrmChild = new Keuangan.frmKasOpnameUpdate(this);
                ifrmChild.Show();
            }
            refreshData();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dgKasOpname.SelectedCells.Count > 0)
            {
                DateTime selectedTgl = Convert.ToDateTime(dgKasOpname.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                // cek tanggalnya, kalau tanggalnya bukan hari ini, ngga boleh
                if (selectedTgl.Date == GlobalVar.GetServerDate.Date)
                {
                    Guid RowID = new Guid(dgKasOpname.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                    Keuangan.frmKasOpnameUpdate ifrmChild = new Keuangan.frmKasOpnameUpdate(this, RowID);
                    ifrmChild.Show();
                }
                // kalau tanggalnya itu hari ini - 2, kena pin
                else if (selectedTgl.Date >= GlobalVar.GetServerDate.Date.AddDays(-2) && selectedTgl.Date < GlobalVar.GetServerDate.Date)
                {
                    // pin
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang,
                                Convert.ToInt32(PinId.ModulId.KasOpnamePrevDay),
                                "Untuk melakukan kas opname sampai 2 hari sebelumnya perlu PIN!");

                    if (GlobalVar.pinResult == false) { return; }
                    else
                    {
                        Guid RowID = new Guid(dgKasOpname.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                        Keuangan.frmKasOpnameUpdate ifrmChild = new Keuangan.frmKasOpnameUpdate(this, RowID);
                        ifrmChild.Show();
                    }
                }
                // selain itu bener2 ngga boleh
                else
                {
                    MessageBox.Show("Tidak dapat mengedit data ini!");
                    return;
                }
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dgKasOpname.SelectedCells.Count > 0)
            {
                DateTime selectedTgl = Convert.ToDateTime(dgKasOpname.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                // cek tanggalnya, kalau tanggalnya bukan hari ini, ngga boleh
                if (selectedTgl.Date == GlobalVar.GetServerDate.Date)
                {
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid RowID = new Guid(dgKasOpname.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_KasOpname_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data berhasil dihapus!");
                            refreshData();
                        }
                    }
                }
                // kalau tanggalnya itu hari ini - 2, kena pin
                else if (selectedTgl.Date >= GlobalVar.GetServerDate.Date.AddDays(-2) && selectedTgl.Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tidak dapat menghapus data ini!");
                    return;
                }
                // selain itu bener2 ngga boleh
                else
                {
                    MessageBox.Show("Tidak dapat menghapus data ini!");
                    return;
                }
            }
        }



    }
}
