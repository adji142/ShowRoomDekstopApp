using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;

namespace ISA.Showroom.Master
{
    public partial class frmJenisKendaraan : ISA.Controls.BaseForm
    {
        Guid _rowID;
        Guid _typeID;
        public frmJenisKendaraan()
        {
            InitializeComponent();
        }

        private void frmJenisKendaraan_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                GVJenisMotor.DataSource = dt;
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (GVJenisMotor.Rows.Count > 0)
            {
                panelAdd.BringToFront();
                panelAdd.Visible = true;
                GVJenisMotor.Enabled = false;
                groupBox1.Enabled = false;
                cmdClose.Enabled = false;
                txtJudul.Text = "Update Harga Type Motor";
                _rowID = Guid.NewGuid();
                _typeID = (Guid)GVJenisMotor.SelectedCells[0].OwningRow.Cells["IDType"].Value;
                txtMerkMotor.Text = GVJenisMotor.SelectedCells[0].OwningRow.Cells["Merk"].Value.ToString();
                txtTypeMotor.Text = GVJenisMotor.SelectedCells[0].OwningRow.Cells["Type"].Value.ToString();
                txtHarga.Text = GVJenisMotor.SelectedCells[0].OwningRow.Cells["Harga"].Value.ToString();
                txtKeterangan.Text = GVJenisMotor.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtHarga.GetDoubleValue <=0)
            {
                MessageBox.Show("Harga harus > 0");
                txtHarga.Focus();
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_CRUD]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TypeID", SqlDbType.UniqueIdentifier, _typeID));
                    db.Commands[0].Parameters.Add(new Parameter("@Harga", SqlDbType.Money, txtHarga.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil disimpan");

                refreshData();
                GVJenisMotor.FindRow("IDType", _typeID.ToString());

                panelAdd.SendToBack();
                panelAdd.Visible = false;
                GVJenisMotor.Enabled = true;
                groupBox1.Enabled = true;
                cmdClose.Enabled = true;
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            panelAdd.SendToBack();
            panelAdd.Visible = false;
            GVJenisMotor.Enabled = true;
            groupBox1.Enabled = true;
            cmdClose.Enabled = true;

        }
    }
}
