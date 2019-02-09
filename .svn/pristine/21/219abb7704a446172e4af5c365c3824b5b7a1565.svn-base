using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Administrasi
{
    public partial class frmPengaturanUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID;

        public frmPengaturanUpdate(Form caller, Guid RowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _rowID = RowID;
        }

        private void frmPengaturanUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ToolTip tooltip1 = new ToolTip();

                tooltip1.AutoPopDelay = 5000;
                tooltip1.InitialDelay = 1000;
                tooltip1.ReshowDelay = 500;
                tooltip1.ShowAlways = true;                                
                tooltip1.SetToolTip(this.txtDepan, "ROMAWIBULAN = mengubah angka bulan ke angka romawi \nBULAN = angka bulan dalam single digit \nBULAN2 = angka bulan dalam 2 digit \nTAHUN = angka tahun dalam 4 digit \nTAHUN2 = angka tahun dalam 2 digit terakhir");
                tooltip1.SetToolTip(this.txtBelakang, "ROMAWIBULAN = mengubah angka bulan ke angka romawi \nBULAN = angka bulan dalam single digit \nBULAN2 = angka bulan dalam 2 digit \nTAHUN = angka tahun dalam 4 digit \nTAHUN2 = angka tahun dalam 2 digit terakhir");

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                txtDepan.Text = Tools.isNull(dt.Rows[0]["Depan"], "").ToString();
                txtBelakang.Text = Tools.isNull(dt.Rows[0]["Belakang"], "").ToString();
                txtLebar.Text = Tools.isNull(dt.Rows[0]["Lebar"], "").ToString();
                if ((bool)Tools.isNull(dt.Rows[0]["Reset"], 0) == false) rbReset2.Checked = true;
                else rbReset1.Checked = true;
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

        private void frmPengaturanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Administrasi.frmPengaturanBrowse)
            {
                Administrasi.frmPengaturanBrowse frmCaller = (Administrasi.frmPengaturanBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("RowID", _rowID.ToString());
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            bool _reset;

            if (rbReset1.Checked == true)
            {
                _reset = true;
            }
            else
            {
                _reset = false;
            }

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Depan", SqlDbType.VarChar, txtDepan.Text.ToLower()));
                    db.Commands[0].Parameters.Add(new Parameter("@Belakang", SqlDbType.VarChar, txtBelakang.Text.ToLower()));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Lebar", SqlDbType.Int, int.Parse(txtLebar.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@Reset", SqlDbType.Bit, _reset));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate !\n " + ex.Message);
            }
        }      
    }
}
