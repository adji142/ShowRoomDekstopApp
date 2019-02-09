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

namespace ISA.Showroom.Master
{
    public partial class frmCostumerBlackListUpdate : ISA.Controls.BaseForm
    {
        string Keterangan = "";
        public enum enumFormMode { Blacklist, Unblacklist };
        public enumFormMode formMode;
        Guid _rowid;
        string _nama;

        public frmCostumerBlackListUpdate(Form caller)
        {
            this.Caller = caller;
            InitializeComponent();
        }

        public frmCostumerBlackListUpdate(Form caller, Guid RowID, string Nama)
        {
            this.Caller = caller;
            _rowid = RowID;
            _nama = Nama;
            InitializeComponent();
        }

        private void lookUpCustomerALL1_SelectData(object sender, EventArgs e)
        {
           SetDatafromLookup();
        }

        private void SetDatafromLookup()
        {
            if (formMode == enumFormMode.Blacklist)
            {
                DataTable dtcek = new DataTable();
                try
                {
                    using (Database db = new Database())
                    {
                        List<Parameter> prm = new List<Parameter>();
                        prm.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomerALL1._customer.RowID));
                        Command cmd = db.CreateCommand("usp_cek_blcaklist");
                        cmd.Parameters = prm;
                        dtcek = cmd.ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (dtcek.Rows.Count > 0)
                {
                    MessageBox.Show("Customer sudah ada di daftar Blacklist !!!");
                    lookUpCustomerALL1.SetByRowID(Guid.Empty);
                    lookUpCustomerALL1._customer.RowID = Guid.Empty;
                    return;
                }
            }

            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    List<Parameter> prm = new List<Parameter>();
                    prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, lookUpCustomerALL1._customer.RowID));
                    Command cmd = db.CreateCommand("usp_Customer_LISTALL");
                    cmd.Parameters = prm;
                    dt = cmd.ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dt.Rows.Count > 0)
            {
                SetInfo(dt);
            }
        }

        private void SetInfo(DataTable dt)
        {
            txtNoIdentitas.Text = dt.Rows[0]["NoIdentitas"].ToString();
            txtAlamatIdt.Text = dt.Rows[0]["AlamatIdt"].ToString();
            txtRTIdt.Text = dt.Rows[0]["RTIdt"].ToString();
            txtRWIdt.Text = dt.Rows[0]["RWIdt"].ToString();
            txtKelurahan.Text = dt.Rows[0]["KelurahanIdt"].ToString();
            txtKecamatan.Text = dt.Rows[0]["KecamatanIdt"].ToString();
            txtKota.Text = dt.Rows[0]["KotaIdt"].ToString();
            txtProvinsi.Text = dt.Rows[0]["ProvinsiIdt"].ToString();
            txtTelp.Text = dt.Rows[0]["NoTelp"].ToString();
            txtHP.Text = dt.Rows[0]["NoHP"].ToString();
            txtCabang.Text = dt.Rows[0]["CabangID"].ToString();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Guid RowID = Guid.NewGuid();
            Guid CustRowID = lookUpCustomerALL1._customer.RowID;
            string NoKTP = txtNoIdentitas.Text;

            if (CustRowID == Guid.Empty)
            {
                MessageBox.Show("Customer Belum Dipilih !!!");
            }
            else
            {
                if (cbTelat.Checked == true)
                {
                    Keterangan = Keterangan + " | TELAT BAYAR > 3 BULAN";
                }
                if (cbBlackList.Checked == true)
                {
                    Keterangan = Keterangan + " | BLACKLIST OLEH LEASING";
                }
                if (cbPiutang.Checked == true)
                {
                    Keterangan = Keterangan + " | MASIH PUNYA PIUTANG";
                }
                if (cbLain.Checked == true && txtKeterangan.Text != "")
                {
                    Keterangan = Keterangan + " | " + txtKeterangan.Text;
                }

                if (formMode == enumFormMode.Blacklist)
                {
                    BlackList_Upsert(RowID, CustRowID, NoKTP, Keterangan.Remove(0, 3));
                }
                else
                {
                    UnBlackList_Upsert(RowID, CustRowID, NoKTP, Keterangan.Remove(0, 3));
                }
                MessageBox.Show("Data berhasil ditambahkan !!!");
                if (this.Caller is frmCostumerBlackList)
                {
                    frmCostumerBlackList frm = (frmCostumerBlackList)this.Caller;
                    frm.RefreshData();
                }

                backgroundWorker1.RunWorkerAsync();
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BlackList_Upsert(Guid _rowID, Guid _custRowID, string _noKTP, string _keterangan)
        {
            try
            {
                using (Database db = new Database())
                {
                    List<Parameter> prm = new List<Parameter>();
                    prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    prm.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, _custRowID));
                    prm.Add(new Parameter("@CustNoKTP", SqlDbType.VarChar, _noKTP));
                    prm.Add(new Parameter("@IsUser", SqlDbType.VarChar, SecurityManager.UserName));
                    prm.Add(new Parameter("@Keterangan", SqlDbType.VarChar, _keterangan));
                    Command cmd = db.CreateCommand("usp_CustomerBlackList");
                    cmd.Parameters = prm;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UnBlackList_Upsert(Guid _rowID, Guid _custRowID, string _noKTP, string _keterangan)
        {
            try
            {
                using (Database db = new Database())
                {
                    List<Parameter> prm = new List<Parameter>();
                    prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    prm.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, _custRowID));
                    prm.Add(new Parameter("@CustNoKTP", SqlDbType.VarChar, _noKTP));
                    prm.Add(new Parameter("@IsUser", SqlDbType.VarChar, SecurityManager.UserName));
                    prm.Add(new Parameter("@Keterangan", SqlDbType.VarChar, _keterangan));
                    Command cmd = db.CreateCommand("usp_CustomerUnBlackList");
                    cmd.Parameters = prm;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbLain_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLain.Checked == true)
            {
                txtKeterangan.Enabled = true;
            }
            else
            {
                txtKeterangan.Enabled = false;
            }
        }

        private void frmCostumerBlackListUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Blacklist)
            {
                Title = "Customer Blacklist";
            }
            else
            {
                Title = "Customer Unblacklist";
                cbTelat.Enabled = false;
                cbTelat.Checked = false;
                cbPiutang.Enabled = false;
                cbPiutang.Checked = false;
                cbBlackList.Enabled = false;
                cbBlackList.Checked = false;
                cbLain.Enabled = true;
                cbLain.Checked = true;
                txtKeterangan.Focus();
                lookUpCustomerALL1.SetByRowID(_rowid);
                lookUpCustomerALL1.Enabled = false;
                SetDatafromLookup();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (formMode == enumFormMode.Blacklist)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_send_customerBlacklist"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            else
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_send_customerUnBlacklist"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }
    }
}
