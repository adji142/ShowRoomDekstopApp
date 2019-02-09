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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmIndenPenjualan : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;
        Guid _RowIDHeader;
        Guid _RowIDDetail;
        DataTable _dataDetailInden;
        string _aksi = "";
        public frmIndenPenjualan()
        {
            InitializeComponent();
        }

        private void frmIndenPenjualan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.DateOfServer.AddDays(-(GlobalVar.DateOfServer.Day-1));
            rangeDateBox1.ToDate = GlobalVar.DateOfServer;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            refreshHeader();
        }

        public void refreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualan_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dt;
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
        public void refreshDetail()
        {
            if (GVHeader.Rows.Count > 0)
            {
                try
                {
                    Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_IndenPenjualanDetail_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    GVDetail.DataSource = dt;
                    _dataDetailInden = dt;
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
            else
            {
                GVDetail.DataSource = null;
            }
        }

        public void FindRow(String ColumnName, String value)
        {
            GVDetail.FindRow(ColumnName, value);
        }

        private void GVHeade_SelectionRowChanged(object sender, EventArgs e)
        {
            refreshDetail();
        }

        private void GVHeade_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
        }

        private void GVDetail_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            _aksi = "add";
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        txtTglInput.DateValue = GlobalVar.DateOfServer;
                        lookUpSalesman1._sales.RowID = Guid.Empty;
                        lookUpSalesman1.txtNamaSales.Text = "";
                        lookUpCustomer1.txtNamaCustomer.Text = "";
                        lookUpCustomer1._customer.RowID = Guid.Empty;
                        txtCatatan.Text = "";

                        panelInden.BringToFront();
                        panelInden.Visible = true;
                        splitContainer1.Enabled = false;
                        groupBox1.Enabled = false;
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeader.Rows.Count > 0)
                        {
                            if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                            {
                                MessageBox.Show("Sudah di Print");
                                return;
                            }
                            lookUpVendor._vendor.RowID = new Guid("1E00E29C-1013-4BD2-9788-3C03BB1B05C1");//Guid.Empty;
                            lookUpVendor.txtNamaVendor.Text = "PT.MITRA PINASTHIKA";
                            lookUpMotor._motor.RowID = Guid.Empty;
                            lookUpMotor.txtNamaMotor.Text = "";
                            txtWarna.Text = "";
                            numTahun.Value = GlobalVar.GetServerDate.Year;
                            txtNominal.Text = "0";
                            txtCatatanDetail.Text = "";

                            panelDetail.BringToFront();
                            panelDetail.Visible = true;
                            splitContainer1.Enabled = false;
                            groupBox1.Enabled = false;
                        }
                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                _aksi = "edit";
                switch (dgS)
                {
                    case enumSelectedGrid.Header:
                        {
                            if (GVDetail.Rows.Count > 0)
                            {
                                MessageBox.Show("Sudah Sudah ada Detail");
                                return;
                            }
                            if (GVHeader.SelectedCells[0].OwningRow.Cells["TotalPesan"].Value.ToString() != "0")
                            {
                                MessageBox.Show("Sudah Ada Detail");
                                return;
                            }
                           
                            _RowIDHeader = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            txtTglInput.DateValue = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglInput"].Value;
                            txtNoInden.Text = GVHeader.SelectedCells[0].OwningRow.Cells["NoInden"].Value.ToString();
                            lookUpSalesman1.txtNamaSales.Text= GVHeader.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
                            lookUpSalesman1._sales.RowID = (Guid)(GVHeader.SelectedCells[0].OwningRow.Cells["SalesID"].Value);
                            lookUpCustomer1.txtNamaCustomer.Text = GVHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                            lookUpCustomer1._customer.RowID = (Guid)(GVHeader.SelectedCells[0].OwningRow.Cells["CustomerID"].Value);
                            txtCatatan.Text = GVHeader.SelectedCells[0].OwningRow.Cells["Catatan"].Value.ToString();

                            panelInden.BringToFront();
                            panelInden.Visible = true;
                            splitContainer1.Enabled = false;
                            groupBox1.Enabled = false;
                        }
                        break;
                    case enumSelectedGrid.Detail:
                        {
                            if (GVHeader.Rows.Count > 0)
                            {
                                if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                                {
                                    MessageBox.Show("Sudah di Print");
                                    return;
                                }

                                if (GVDetail.Rows.Count > 0)
                                {
                                    if (GVDetail.SelectedCells[0].OwningRow.Cells["LinkPenjualan"].Value.ToString() == "1")
                                    {
                                        MessageBox.Show("Sudah di Link Ke Penjualan");
                                        return;
                                    }
                                    lookUpVendor._vendor.RowID = (Guid)(GVDetail.SelectedCells[0].OwningRow.Cells["VendorID"].Value);
                                    lookUpVendor.txtNamaVendor.Text = GVDetail.SelectedCells[0].OwningRow.Cells["NamaVendor"].Value.ToString();
                                    lookUpMotor._motor.RowID = (Guid)(GVDetail.SelectedCells[0].OwningRow.Cells["TypeMotorID"].Value);
                                    lookUpMotor.txtNamaMotor.Text = GVDetail.SelectedCells[0].OwningRow.Cells["MerkMotor"].Value.ToString() + GVDetail.SelectedCells[0].OwningRow.Cells["TypeMotor"].Value.ToString();
                                    txtWarna.Text = GVDetail.SelectedCells[0].OwningRow.Cells["WarnaMotor"].Value.ToString();
                                    numTahun.Value = Convert.ToDecimal(GVDetail.SelectedCells[0].OwningRow.Cells["TahunPembuatan"].Value);
                                    txtNominal.Text = GVDetail.SelectedCells[0].OwningRow.Cells["NominalTitip"].Value.ToString();
                                    txtCatatanDetail.Text = GVDetail.SelectedCells[0].OwningRow.Cells["CatatanDetail"].Value.ToString();

                                    panelDetail.BringToFront();
                                    panelDetail.Visible = true;
                                    splitContainer1.Enabled = false;
                                    groupBox1.Enabled = false;
                                }
                            }
                        }
                        break;

                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeader.Rows.Count > 0)
                        {
                            if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                            {
                                MessageBox.Show("Sudah di Print");
                                return;
                            }

                            if (GVHeader.SelectedCells[0].OwningRow.Cells["TotalPesan"].Value.ToString() != "0")
                            {
                                MessageBox.Show("Hapus Detail Terlebih Dahulu");
                                return;
                            }
                            if (MessageBox.Show("Anda yakin akan menghapus data ini ?","Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                    this.Cursor = Cursors.WaitCursor;
                                    DataTable dt;
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_IndenPenjualan_CRUD"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID_));
                                        db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, "delete"));
                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                    refreshHeader();
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
                        }
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeader.Rows.Count > 0)
                        {
                            if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                            {
                                MessageBox.Show("Sudah di Print");
                                return;
                            }
                            if (GVDetail.Rows.Count > 0)
                            {
                                if (GVDetail.SelectedCells[0].OwningRow.Cells["LinkPenjualan"].Value.ToString() == "1")
                                {
                                    MessageBox.Show("Sudah di Link ke Penjualan");
                                    return;
                                }
                                if (GVDetail.SelectedCells[0].OwningRow.Cells["LinkJurnal"].Value.ToString() == "1")
                                {
                                    MessageBox.Show("Sudah di Jurnal");
                                    return;
                                }
                                if (MessageBox.Show("Anda yakin akan menghapus data ini ?", "Hapus Data",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                        Guid DetailID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                                        this.Cursor = Cursors.WaitCursor;
                                        DataTable dt;
                                        using (Database db = new Database())
                                        {
                                            db.Commands.Add(db.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DetailID_));
                                            db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, "delete"));
                                            db.Commands[0].ExecuteNonQuery();
                                        }
                                        refreshHeader();
                                        GVHeader.FindRow("RowID", HeaderID_.ToString());
                                        refreshDetail();
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
                            }
                        }
                    }
                    break;
            }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpSalesman1._sales.RowID == Guid.Empty)
                {
                    MessageBox.Show("Sales belum diisi");
                    return;
                }

                if (lookUpCustomer1._customer.RowID == Guid.Empty)
                {
                    MessageBox.Show("Customer belum diisi");
                    return;
                }

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Customer_Blacklist_OnlyOne"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Customer Merupakan Customer Blacklist");
                        return;
                    }
                }

                if (_aksi == "add")
                {
                    _RowIDHeader = Guid.NewGuid();
                    txtNoInden.Text = Numerator.NextNumber("IPJ");
                }
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualan_CRUD"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@NoInden", SqlDbType.VarChar, txtNoInden.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglInput", SqlDbType.DateTime, txtTglInput.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CustomerID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, _aksi));
                    db.Commands[0].ExecuteNonQuery();
                }
                refreshHeader();
                GVHeader.FindRow("RowID", _RowIDHeader.ToString());

                panelInden.SendToBack();
                panelInden.Visible = false;
                splitContainer1.Enabled = true;
                groupBox1.Enabled = true;
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
            panelInden.SendToBack();
            panelInden.Visible = false;
            splitContainer1.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void cmdSaveDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpVendor._vendor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Vendor belum diisi");
                    lookUpVendor.Focus();
                    return;
                }

                if (lookUpMotor._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Type Motor belum diisi");
                    lookUpMotor.Focus();
                    return;
                }

                if (txtWarna.Text == "")
                {
                    MessageBox.Show("Warna belum diisi");
                    txtWarna.Focus();
                    return;
                }

                //if (txtNominal.GetDoubleValue < 1000000)
                //{
                //    MessageBox.Show("Nominal Titip harus >= Rp 1.000.000");
                //    txtNominal.Focus();
                //    return;
                //}
                
                if (txtNominal.GetDoubleValue < 200000)
                {
                    MessageBox.Show("Nominal Titip harus >= Rp 200.000");
                    txtNominal.Focus();
                    return;
                }

                if (_aksi == "add")
                {
                    _RowIDDetail = Guid.NewGuid();
                }

                Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDDetail));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorID", SqlDbType.UniqueIdentifier, lookUpVendor._vendor.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TypeMotorID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txtWarna.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TahunPEmbuatan", SqlDbType.VarChar, numTahun.Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue)); 
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatanDetail.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, _aksi));
                    db.Commands[0].ExecuteNonQuery();
                }
                refreshHeader();
                GVHeader.FindRow("RowID", HeaderID_.ToString());
                refreshDetail();
                GVDetail.FindRow("RowIDDetail", _RowIDDetail.ToString());

                panelDetail.SendToBack();
                panelDetail.Visible = false;
                splitContainer1.Enabled = true;
                groupBox1.Enabled = true;
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

        private void cmdCloseDetail_Click(object sender, EventArgs e)
        {
            panelDetail.SendToBack();
            panelDetail.Visible = false;
            splitContainer1.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void cmdLinkPJ_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "0")
                {
                    MessageBox.Show("Inden belum di Print");
                    return;
                }
                if (GVDetail.Rows.Count > 0)
                {
                    if (GVDetail.SelectedCells[0].OwningRow.Cells["LinkPenjualan"].Value.ToString() == "1")
                    {
                        MessageBox.Show("Sudah di link ke Penjualan");
                        return;
                    }

                    if (!cekStockTersedia())
                    {
                        MessageBox.Show("Stock belum tersedia");
                        return;
                    }
                    Guid _rowID = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                    Guid _salesID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["SalesID"].Value;
                    string _namaSales = GVHeader.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
                    Guid _customerid = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["CustomerID"].Value;
                    string _namacustomer = GVHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();

                    string _namavendor = GVDetail.SelectedCells[0].OwningRow.Cells["NamaVendor"].Value.ToString();
                    string _merkmotor = GVDetail.SelectedCells[0].OwningRow.Cells["MerkMotor"].Value.ToString();
                    string _typemotor = GVDetail.SelectedCells[0].OwningRow.Cells["TypeMotor"].Value.ToString();

                    string _warnamototr = GVDetail.SelectedCells[0].OwningRow.Cells["WarnaMotor"].Value.ToString();
                    string _tahunpembuatan = GVDetail.SelectedCells[0].OwningRow.Cells["TahunPembuatan"].Value.ToString();

                    string _keterangan = "Vendor : " + _namacustomer + "Type Motor " + _merkmotor + _typemotor + " warna " + _warnamototr + " tahun " + _tahunpembuatan;

                    double _nominalTitip = double.Parse(GVDetail.SelectedCells[0].OwningRow.Cells["NominalTitip"].Value.ToString());

                    Penjualan.frmPenjualanUpdateTLA ifrmChild = new Penjualan.frmPenjualanUpdateTLA(this, _rowID, _salesID, _namaSales, _customerid, _namacustomer, _keterangan, _nominalTitip);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
            }

        }

        private bool cekStockTersedia()
        {
            bool _hasil = false;
            try
            {
                Guid DetailID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualan_cekKesesuaianMotort"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDIndenDetail", SqlDbType.UniqueIdentifier, DetailID_));
                    dt=db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    _hasil = true;
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

            return _hasil;
        }

        public void insertlinkPJ(Guid RowID)
        {
            try
            {
                Guid DetailID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DetailID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PJRowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, "linkPJ"));
                    db.Commands[0].ExecuteNonQuery();
                }

                //insertpengeluaranUang();

                refreshDetail();
                GVDetail.FindRow("RowIDDetail", DetailID_.ToString());
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

        private void GVDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (GVDetail.SelectedCells.Count == 0) return;
            foreach (DataGridViewRow aa in GVDetail.Rows)
            {
                if (aa.Cells["BatalInden"].Value.ToString() == "1")
                {
                    aa.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
                }

                else if (aa.Cells["LinkPenjualan"].Value.ToString() == "1")
                {
                    aa.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                Guid _indenRowID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DateTime _tglInden = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglInput"].Value;

                string _noInden = GVHeader.SelectedCells[0].OwningRow.Cells["NoInden"].Value.ToString();
                double _rpinden = Convert.ToDouble(GVHeader.SelectedCells[0].OwningRow.Cells["TotalTitip"].Value);

                string _totRpInden="Rp "+_rpinden.ToString("N0");

                if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                {
                    if (MessageBox.Show("NotaSudah pernah dicetak. Apakah Anda ingin mencetak ulang ?", "Print Ulang",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                if (_dataDetailInden.Rows.Count == 0)
                {
                    MessageBox.Show("Belum Ada Inden");
                    return;
                }

                try
                {
                    int _nprint;
                    
                    frmPrint ifrmDialog = new frmPrint(this, 3);
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.Yes)
                    { _nprint = ifrmDialog.Result; }
                    else
                    { return; }

                    String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileName = "";
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "WMF4ASLI"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_Path = IMG_Path + FileName;

                    String IMG_PathCOPY = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileNameCOPY = "";
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "WMF4COPY"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileNameCOPY = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_PathCOPY = IMG_PathCOPY + FileNameCOPY;

                    String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileNameBW = "";
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_PathBW = IMG_PathBW + FileNameBW;
                    string IPserver = ISA.DAL.Database.Host;

                    String KWKSNG = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileNameKWKSNG = "";
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KWKSNG"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileNameKWKSNG = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    KWKSNG = KWKSNG + FileNameKWKSNG;

                    DataSet ds;
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_IndenPenjualan_LapKetInden"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@IndenRowID", SqlDbType.UniqueIdentifier, _indenRowID));
                        ds = dbLogo.Commands[0].ExecuteDataSet();
                    }

                    List<DataTable> pTable = new List<DataTable>();
                    pTable.Add(ds.Tables[0]);
                    pTable.Add(ds.Tables[1]);
                    pTable.Add(_dataDetailInden);

                    List<string> pDatasetName = new List<string>();
                    pDatasetName.Add("dsPenjualan_PT");
                    pDatasetName.Add("dsPenjualan_Faktur");
                    pDatasetName.Add("dsPenjualan_IndenPenjualan");


                    IMG_PathBW = IMG_PathBW + FileNameBW;
                    List<ReportParameter> rptParams = new List<ReportParameter>();

                    rptParams.Add(new ReportParameter("Tgl", GlobalVar.GetServerDateTime.ToString("dd-MM-yyyy")));
                    rptParams.Add(new ReportParameter("Tahun", _tglInden.Year.ToString()));
                    rptParams.Add(new ReportParameter("TglJual", _tglInden.ToString("dd-MM-yyyy")));
                    rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));

                    rptParams.Add(new ReportParameter("IMG_PathCopy", IMG_PathCOPY));
                    rptParams.Add(new ReportParameter("IMG_PathCopy2", IMG_Path));

                    if (IPserver == "172.16.61.253")
                        rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));
                    else
                        rptParams.Add(new ReportParameter("IMG_PathBW", ""));


                    rptParams.Add(new ReportParameter("KWKSNG", KWKSNG));
                    rptParams.Add(new ReportParameter("NoDok", _noInden));
                    rptParams.Add(new ReportParameter("RpTotal", _totRpInden));


                    if ((_nprint == 0) || (_nprint == 1))
                    {
                        frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiInden.rdlc", rptParams, pTable, pDatasetName);
                        ifrmReport.Print();
                    }
                    if ((_nprint == 0) || (_nprint == 2))
                    {
                        frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiIndenCopy1.rdlc", rptParams, pTable, pDatasetName);
                        ifrmReport.Print();
                    }
                    if ((_nprint == 0) || (_nprint == 3))
                    {
                        frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiIndenCopy2.rdlc", rptParams, pTable, pDatasetName);
                        ifrmReport.Print();
                    }

                    if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "0")
                    {
                        insertPenerimaanUang();
                    }

                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_IndenPenjualan_Print"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@IndenRowID", SqlDbType.UniqueIdentifier, _indenRowID));
                        dbLogo.Commands[0].ExecuteNonQuery();
                    }
                    
                    refreshHeader();
                    GVHeader.FindRow("RowID", _indenRowID.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal dicetak !\n" + ex.Message);
                }
            }
        }

        private void insertPenerimaanUang()
        {
            try
            {

                for (int i = 0; i < _dataDetailInden.Rows.Count; i++)
                {
                    string _keterangan = "Titipan Inden " + GVHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                    _keterangan=_keterangan+" Merk/Type : "+_dataDetailInden.Rows[i]["MerkMotor"].ToString()+"-"+_dataDetailInden.Rows[i]["TypeMotor"].ToString()+" Th "+_dataDetailInden.Rows[i]["TahunPembuatan"].ToString()+" "+_dataDetailInden.Rows[i]["WarnaMotor"].ToString();

                    Guid _indenid = (Guid)_dataDetailInden.Rows[i]["RowID"];

                    Guid _rowID = Guid.NewGuid();

                    using(Database db = new Database(GlobalVar.DBFinanceOto))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));

                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, "0"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid("BC17A644-5DBD-4955-A803-378F8C0A915C")));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid("20D04216-60F4-4FD9-940B-4AFCE91892EC")));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDouble(_dataDetailInden.Rows[i]["NominalTitip"])));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Convert.ToDouble(_dataDetailInden.Rows[i]["NominalTitip"])));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _keterangan));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, new Guid("E6768D8C-975C-4DC2-BF20-CF80DC1AF12E")));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _indenid));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangID", SqlDbType.UniqueIdentifier, _rowID));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, "updatepenerimaan"));
                        dbLogo.Commands[0].ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void insertpengeluaranUang()
        {
            try
            {

                    string _keterangan = "Realisasi Inden " + GVHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                    _keterangan = _keterangan + " Merk/Type : " + GVDetail.SelectedCells[0].OwningRow.Cells["MerkMotor"].Value.ToString() + "-" + GVDetail.SelectedCells[0].OwningRow.Cells["TypeMotor"].Value.ToString() + " Th " + GVDetail.SelectedCells[0].OwningRow.Cells["TahunPembuatan"].Value.ToString() + " " + GVDetail.SelectedCells[0].OwningRow.Cells["WarnaMotor"].Value.ToString();

                    double _nominal=Convert.ToDouble(GVDetail.SelectedCells[0].OwningRow.Cells["NominalTitip"].Value);
                    Guid _indenid = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                    Guid _rowID = Guid.NewGuid();

                    using (Database db = new Database(GlobalVar.DBFinanceOto))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_INSERT"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid("BC17A644-5DBD-4955-A803-378F8C0A915C")));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid("20D04216-60F4-4FD9-940B-4AFCE91892EC")));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, _nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _keterangan));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));

                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, "9"));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, new Guid("E6768D8C-975C-4DC2-BF20-CF80DC1AF12E")));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@KeKasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@KeRekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, "2"));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                    }
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _indenid));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangID", SqlDbType.UniqueIdentifier, _rowID));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, "updatepengeluaran"));
                        dbLogo.Commands[0].ExecuteNonQuery();
                    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void insertbatalinden()
        {
            try
            {

                    string _keterangan = "Batal Inden " + GVHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                    _keterangan = _keterangan + " Merk/Type : " + GVDetail.SelectedCells[0].OwningRow.Cells["MerkMotor"].Value.ToString() + "-" + GVDetail.SelectedCells[0].OwningRow.Cells["TypeMotor"].Value.ToString() + " Th " + GVDetail.SelectedCells[0].OwningRow.Cells["TahunPembuatan"].Value.ToString() + " " + GVDetail.SelectedCells[0].OwningRow.Cells["WarnaMotor"].Value.ToString();

                    double _nominal=Convert.ToDouble(GVDetail.SelectedCells[0].OwningRow.Cells["NominalTitip"].Value);
                    Guid _indenid = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                    Guid _rowID = Guid.NewGuid();

                    using (Database db = new Database(GlobalVar.DBFinanceOto))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_INSERT"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid("BC17A644-5DBD-4955-A803-378F8C0A915C")));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid("6535700F-FEB3-414F-ABA1-92500FD2A9BD")));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, _nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _keterangan));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));

                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, "9"));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, new Guid("E6768D8C-975C-4DC2-BF20-CF80DC1AF12E")));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@KeKasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@KeRekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, "2"));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                    }
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_IndenPenjualanDetail_CRUD"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _indenid));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangID", SqlDbType.UniqueIdentifier, _rowID));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, "batalinden"));
                        dbLogo.Commands[0].ExecuteNonQuery();
                    }

                    refreshDetail();
                    GVDetail.FindRow("RowIDDetail", _indenid.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal proses batal inden !\n" + ex.Message);
            }
        }

        private void cmdBatalInden_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                if (GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "0")
                {
                    MessageBox.Show("Inden belum di Print");
                    return;
                }

                if(GVDetail.Rows.Count>0)
                {
                    if (GVDetail.SelectedCells[0].OwningRow.Cells["LinkPenjualan"].Value.ToString() == "1")
                    {
                        MessageBox.Show("Sudah di Link Ke Penjualan");
                        return;
                    }

                    if(GVDetail.SelectedCells[0].OwningRow.Cells["BatalInden"].Value.ToString()=="1")
                    {
                        MessageBox.Show("Sudah di batal Inden");
                        return;
                    }

                    if (MessageBox.Show("Anda yakin akan membatalkan inden ini ?","Batal Inden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        insertbatalinden();
                    }
                }
             }
        }

        private void lookUpCustomer1_SelectData(object sender, EventArgs e)
        {
            try
            {
                if (lookUpCustomer1._customer.RowID != Guid.Empty)
                {
                    Guid CustID = lookUpCustomer1._customer.RowID;

                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Customer_Blacklist_OnlyOne"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, CustID));
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Customer Merupakan Customer Blacklist");
                            lookUpCustomer1._customer.RowID = Guid.Empty;
                            lookUpCustomer1._customer.NamaCustomer = "";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
