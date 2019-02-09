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
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmDPSubsidiBrowse : ISA.Controls.BaseForm
    {
        Guid _penjRowID;

        public frmDPSubsidiBrowse(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            _penjRowID = PenjRowID;
            this.Caller = Caller;
        }

        private void frmDPSubsidiBrowse_Load(object sender, EventArgs e)
        {
            cmdDELETE.Enabled = false;
            cmdDELETE.Visible = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_DPSubsidiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgDPSubsidi.DataSource = dt;
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if(dgDPSubsidi.SelectedCells.Count > 0)
            {
                Guid selectedRowID = new Guid (Tools.isNull(dgDPSubsidi.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());
                String KodeTrans = Tools.isNull(dgDPSubsidi.SelectedCells[0].OwningRow.Cells["KodeTrans"].Value, "").ToString();

                if (KodeTrans.ToUpper().Trim() == "SBD")
                {
                    // ngga boleh hapus SBD
                    MessageBox.Show("Tidak dapat menghapus data ini");
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_DPSubsidiDetail_isDeletable"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, selectedRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                        
                    Double toBeDeleted = Convert.ToDouble(Tools.isNull(dt.Rows[0]["toBeDeleted"], 0).ToString());
                    Double Total = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Total"], 0).ToString());
                    Double Paid = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Paid"], 0).ToString());

                    if (Total - toBeDeleted < Paid)
                    {
                        MessageBox.Show("Tidak dapat menghapus data ini");
                        return;
                    }
                    else
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Penjualan_DPSubsidiDetail_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, selectedRowID));
                            db.Commands[0].ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus!");
                            return;
                        }
                    }
                }
            }
        }
    }
}
