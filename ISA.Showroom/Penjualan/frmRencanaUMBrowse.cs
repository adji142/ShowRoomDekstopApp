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
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ISA.Showroom.Penjualan
{
    public partial class frmRencanaUMBrowse : ISA.Controls.BaseForm
    {
        Guid _penjRowID;

        public frmRencanaUMBrowse(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            this.Caller = Caller;
            _penjRowID = PenjRowID;
        }

        private void frmRencanaUMBrowse_Load(object sender, EventArgs e)
        {
            DataTable dtCTP = new DataTable();
            using (Database dbsub = new Database())
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_PenjualanCashTempoDPDetail_LIST"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dtCTP = dbsub.Commands[0].ExecuteDataTable();
                // dgFile.DataSource = _dtFile; // ngga bisa pake data source biar bisa tetep diedit
                // harus masukkin satu per satu
                int i = 0, tempcurrent;
                for (i = 0; i < dtCTP.Rows.Count; i++)
                {
                    tempcurrent = dgDetailCTP.Rows.Add();
                    dgDetailCTP.Rows[tempcurrent].Cells["Nominal"].Value = Convert.ToDouble(dtCTP.Rows[tempcurrent]["Nominal"]).ToString("N2");
                    dgDetailCTP.Rows[tempcurrent].Cells["Tanggal"].Value = Convert.ToDateTime(dtCTP.Rows[tempcurrent]["TglBayar"]).ToString("d");
                    dgDetailCTP.Rows[tempcurrent].Cells["Uraian"].Value = dtCTP.Rows[tempcurrent]["Uraian"].ToString();
                }
            }
            dgDetailCTP.ReadOnly = true;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
