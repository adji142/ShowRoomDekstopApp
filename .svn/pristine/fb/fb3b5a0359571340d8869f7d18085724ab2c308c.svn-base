using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmIdenPelunasanBBN : ISA.Controls.BaseForm
    {
        Guid _HeaderID;
        public frmIdenPelunasanBBN()
        {
            InitializeComponent();
        }

        public frmIdenPelunasanBBN(Form Caller, Guid RowID)
        {
            InitializeComponent();
            _HeaderID = RowID;
            this.Caller = Caller;
        }

        private void frmIdenPelunasanBBN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN_ListDaftarBBN"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                GVDetail.DataSource = dtHeader;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Data");
            dt.Columns.Add("RowID", typeof(string));

            foreach (DataGridViewRow row in GVDetail.Rows)
            {
                int rowIndex = row.Index;
                if (Convert.ToBoolean(GVDetail.Rows[rowIndex].Cells["check"].Value) == true)
                {
                    DataRow dr = null;
                    DataTable dt2 = dt;
                    dr = dt2.Rows.Add();
                    dr["RowID"] = GVDetail.Rows[rowIndex].Cells["RowID"].Value.ToString();
                }
            }

            try
            {
                StringWriter w = new StringWriter();
                dt.WriteXml(w);

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN_AddDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@DataXml", SqlDbType.Xml, w.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.closeForm();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GVDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
            {
                if (Convert.ToBoolean(GVDetail.Rows[0].Cells["check"].Value) == true)
                {
                    foreach (DataGridViewRow row in GVDetail.Rows)
                    {
                        row.Cells["check"].Value = false;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in GVDetail.Rows)
                    {
                        row.Cells["check"].Value = true;
                    }
                }
            }
            else
            {
                if (Convert.ToBoolean(GVDetail.Rows[rowIndex].Cells["check"].Value) == true)
                {
                    GVDetail.Rows[rowIndex].Cells["check"].Value = false;
                }
                else
                {
                    GVDetail.Rows[rowIndex].Cells["check"].Value = true;
                }
            }
        }
        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPengajuanBBN)
                {
                    frmPengajuanBBN ifrmcaller = (frmPengajuanBBN)this.Caller;
                    ifrmcaller.RefreshHeader(_HeaderID);
                }
            }
            this.Close();
        }
    }
}
