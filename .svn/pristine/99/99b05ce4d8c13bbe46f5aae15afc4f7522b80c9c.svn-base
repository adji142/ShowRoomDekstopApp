using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//koneksi ke SQL SERVER
using System.Configuration;
using ISA.DAL;
//untuk keperluan dBase
using System.IO;
using System.Globalization;
using System.Data.OleDb;

namespace ISA.To.GLDOS
{
    public partial class ToGL : System.Windows.Forms.Form
    {
        #region Declarations
        //Guid rowid;
        int rfresh; string kdgudang; string nmgudang; string sqlerror;
        string idrec; DateTime tanggal; string referensi; string no_perk; string keterangan; double jumlah; 
        string ctanggal; string id_adjust; string kdcabang; string idtrdrlain; string kdcostcntr; string nmcostcntr;
        string idtr; DateTime tgl_po; string no_po; DateTime tgl_sj; string no_sj; DateTime tgl_nota; 
        string no_nota; DateTime tgl_terima; string no_spp; DateTime tgl_spp; string kd_supp; string supplier;
        string kd_expd; double nil_brutt; double disc1; double disc2; double disc3; double ndisc1; double ndisc2; double ndisc3; 
        double pot; double nil_nett; double ppn; double nppn; double dpp; int jwb; string idmatch; string idlink; 
        string kd_dept; string dept; string subdept;
        List<string> files = new List<string>();
        string direk = System.Configuration.ConfigurationSettings.AppSettings.Get("dirfol");
        string direk2 = System.Configuration.ConfigurationSettings.AppSettings.Get("dirgl");
        string jurnal = System.Configuration.ConfigurationSettings.AppSettings.Get("jurnal");
        string htransb = System.Configuration.ConfigurationSettings.AppSettings.Get("htransb");
        string dtransb = System.Configuration.ConfigurationSettings.AppSettings.Get("dtransb");
        string hpb_prod = System.Configuration.ConfigurationSettings.AppSettings.Get("hpb_prod");
        string dpb_prod = System.Configuration.ConfigurationSettings.AppSettings.Get("dpb_prod");
        string gudang = System.Configuration.ConfigurationSettings.AppSettings.Get("gudang");
        string stokbb = System.Configuration.ConfigurationSettings.AppSettings.Get("stokbb");
        string stokjd = System.Configuration.ConfigurationSettings.AppSettings.Get("stokjd");
        DataTable jurnalDB = new DataTable(); DataTable dbgrid = new DataTable(); DataTable dbgridd = new DataTable();
        DataTable dtmaterial = new DataTable(); DataTable dtsuppd = new DataTable(); DataTable dtsupps = new DataTable();
        DataTable vgudang = new DataTable(); DataTable dosgudang = new DataTable(); DataTable dosstok = new DataTable();
        SqlConnection koneksi = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ISA.To.GLDOS.Properties.Settings.sqlcon"].ConnectionString);
        OleDbConnection dbfkoneksi = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ISA.To.GLDOS.Properties.Settings.dbfcon"].ConnectionString);
        OleDbConnection dbfkoneksigl = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ISA.To.GLDOS.Properties.Settings.dbfgl"].ConnectionString);
        #endregion
        #region Inisial banget
        public ToGL()
        {
            InitializeComponent();
            //untuk try
            notifyicon1 = new NotifyIcon();
            contextmenu1 = new ContextMenu();
            contextmenu1.MenuItems.Add(m1 = new MenuItem("&Restore App"));
            contextmenu1.MenuItems.Add(new MenuItem("-"));
            contextmenu1.MenuItems.Add(m2 = new MenuItem("&Exit"));
            m1.Click += new EventHandler(m1_Click);
            m2.Click += new EventHandler(m2_Click);
            this.notifyicon1.Icon = new Icon("File MS-Dos Batch.ico");
            this.notifyicon1.ContextMenu = this.contextmenu1;
            this.notifyicon1.Text = "Notify Icon Using Code";
            this.notifyicon1.Visible = true;
        }
        #endregion
        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox1.Location = new Point(130, 33);
            groupBox2.Location = new Point(12, 27);
            groupBox2.Text = "Data Pembelian";
            komando();
            buattxt();
            label12.Visible = false;
            progressBar1.Visible = false;
            label3.Text = DirProject();
        }
        #endregion

        #region pembelian
        public void dostampil()
        {
            dbfkoneksi.Open();
            OleDbCommand oComm = dbfkoneksi.CreateCommand();
            string ceksql = "select * from " + direk2 + jurnal + " where no_perk like '%" + commonTextBox2.Text + "%'";
            oComm.CommandText = ceksql;
            DataTable oDs = new DataTable();
            oDs.Load(oComm.ExecuteReader());
            dbfkoneksi.Close();
            //Application.StartupPath+"\dbf"
            dataGridView1.DataSource = oDs;
            label4.Text = "Input data Jurnal Tanggal Hari ini : " + DateTime.Now.ToShortDateString();
        }
        public void jutampil()
        {
            dbfkoneksi.Open();
            OleDbCommand oComm = dbfkoneksi.CreateCommand();
            string ceksql = "select * from " + direk2 + jurnal + " where no_perk like '%" + commonTextBox2.Text + "%'";
            oComm.CommandText = ceksql;
            DataTable oDs = new DataTable();
            oDs.Load(oComm.ExecuteReader());
            dbfkoneksi.Close();
            dataGridView4.DataSource = oDs;
        }
        public void komando()
        {
            try
            {
                DateTime startTime = DateTime.Now;
                koneksi.Open();
                SqlDataReader myReader = null;
                int awaltgl = DateTime.Now.Day; awaltgl = awaltgl - 1;
                SqlCommand cmdquery = new SqlCommand("vsp_Pembelian", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@Tanggal1", DateTime.Now.AddDays(-awaltgl).ToShortDateString()));
                cmdquery.Parameters.Add(new SqlParameter("@Tanggal2", DateTime.Now.ToShortDateString()));
                myReader = cmdquery.ExecuteReader();
                dbgrid.Clear();
                dbgrid.Load(myReader);
                int jmlrow = dbgrid.Rows.Count;
                dataGridView2.DataSource = dbgrid;
                label5.Text = "Pembelian, " + jmlrow + " Data dari " + DateTime.Now.AddDays(-awaltgl).ToShortDateString() + " s/d " + DateTime.Now.ToShortDateString();
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void komandoD()
        {
            try
            {
                progressBar1.Value = 0;
                DateTime startTime = DateTime.Now;
                koneksi.Open();
                SqlDataReader myReader = null;
                SqlCommand cmdquery = new SqlCommand("vsp_PembelianDetail", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add("@IdRec", SqlDbType.VarChar).Value=idrec;
                //cmdquery.Parameters.Add("@Cek", SqlDbType.VarChar).Value = "T";
                myReader = cmdquery.ExecuteReader();
                dbgridd.Clear();
                dbgridd.Load(myReader);
                int jmlrowd = dbgridd.Rows.Count;
                dataGridView3.DataSource = dbgridd;
                label11.Text = "Detail Pembelian, " + jmlrowd + " Data";
                DateTime endTime = DateTime.Now;
                TimeSpan coba = endTime.Subtract(startTime);
                progressBar1.MarqueeAnimationSpeed = coba.Milliseconds;
                progressBar1.Value = 100;
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void u_komando()
        {
            try
            {
                koneksi.Open();
                SqlDataReader myReader = null;
                int awaltgl = DateTime.Now.Day; awaltgl = awaltgl - 1;
                SqlCommand cmdquery = new SqlCommand("usp_Pembelian", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@NONOTA", no_nota));
                cmdquery.ExecuteNonQuery();
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void addbeli()
        {
            try
            {
                DateTime skrg = DateTime.Today;
                dbfkoneksi.Open();
                using (OleDbCommand oComm = dbfkoneksi.CreateCommand())
                foreach (DataRow brs in dbgrid.Rows)
                {
                    DateTime startTime = DateTime.Now;
                    idrec = brs["Idrec"].ToString();
                    tanggal = Convert.ToDateTime(brs["TglTerima"].ToString());
                    referensi = brs["NoNota"].ToString().Trim();
                    no_perk = brs["NoPerkiraan"].ToString();
                    jumlah = Convert.ToDouble(brs["RpTerima"].ToString());
                    ctanggal = "IN DITOX"; id_adjust = ""; kdcabang = "017"; idtrdrlain = ""; kdcostcntr = ""; nmcostcntr = "";
                    //htransb dan hpb_prod
                    no_po = brs["NoPo"].ToString().Trim();
                    tgl_po = Convert.ToDateTime(brs["TglPo"].ToString());
                    no_sj = brs["NoNota"].ToString().Trim();
                    tgl_sj = Convert.ToDateTime(brs["TglNota"].ToString());
                    no_nota = brs["NoNota"].ToString().Trim();
                    tgl_nota = Convert.ToDateTime(brs["TglNota"].ToString());
                    tgl_terima = Convert.ToDateTime(brs["TglTerima"].ToString());
                    //no_spp = "";tgl_spp = "";
                    kd_supp = brs["KodeSupplier"].ToString().Trim();
                    supplier = brs["Supplier"].ToString().Trim();//kosong
                    kd_expd = "";//kosong
                    nil_brutt = Convert.ToDouble(brs["RpTerima"].ToString(), System.Globalization.CultureInfo.InvariantCulture);//kosong
                    disc2 = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                    disc3 = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    ndisc1 = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                    ndisc2 = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                    ndisc3 = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    pot = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    nil_nett = Convert.ToDouble(brs["RpTerima"].ToString(), System.Globalization.CultureInfo.InvariantCulture);//kosong
                    ppn = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    nppn = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    dpp = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);//kosong
                    jwb = 0; idmatch = ""; idlink = ""; kd_dept = brs["KodeDep"].ToString().Trim();//kosong
                    dept = brs["UnitProduksi"].ToString().Trim(); subdept = brs["UnitProduksi"].ToString().Trim();//kosong 
                    komandoD();

                    DateTime myDate = DateTime.Now;
                    label4.Text = "Input data Jurnal Tanggal Hari ini : " + DateTime.Now.ToShortDateString();
                    oComm.CommandText = "Insert into " + direk2 + jurnal + "(tanggal,referensi,no_perk,keterangan,jumlah,idrec,ctanggal,id_adjust,kdcabang,idtrdrlain,kdcostcntr,nmcostcntr)" +
                        "values({^" + tanggal.ToShortDateString() + "},'" + referensi + "','702.100','Pembelian B.B " +
                        kd_supp + "'," + jumlah + ",'" + idrec + "','" + ctanggal + "','" + id_adjust + "','" +
                        kdcabang + "','" + idtrdrlain + "','" + kdcostcntr + "','" + nmcostcntr + "')";
                    oComm.ExecuteNonQuery();
                    oComm.CommandText = "Insert into " + direk2 + jurnal + "(tanggal,referensi,no_perk,keterangan,jumlah,idrec,ctanggal,id_adjust,kdcabang,idtrdrlain,kdcostcntr,nmcostcntr)" +
                        "values({^" + tanggal.ToShortDateString() + "},'" + referensi + "','920.400','PPN Pembelian B.B " +
                        kd_supp + "'," + ppn + ",'" + idrec + "','" + ctanggal + "','" + id_adjust + "','" +
                        kdcabang + "','" + idtrdrlain + "','" + kdcostcntr + "','" + nmcostcntr + "')";
                    oComm.ExecuteNonQuery();
                    oComm.CommandText = "Insert into " + direk2 + jurnal + "(tanggal,referensi,no_perk,keterangan,jumlah,idrec,ctanggal,id_adjust,kdcabang,idtrdrlain,kdcostcntr,nmcostcntr)" +
                        "values({^" + tanggal.ToShortDateString() + "},'" + referensi + "','" + no_perk + "','Pembelian B.B " +
                        kd_supp + "'," + (jumlah * -1) + ",'" + idrec + "','" + ctanggal + "','" + id_adjust + "','" +
                        kdcabang + "','" + idtrdrlain + "','" + kdcostcntr + "','" + nmcostcntr + "')";
                    oComm.ExecuteNonQuery();

                    oComm.CommandText = "Insert into " + direk + htransb + "(idtr,tgl_po,no_po,tgl_sj,no_sj,tgl_nota" +
                        ",no_nota,tgl_terima,kd_supp,supplier,nil_brutt,disc1,disc2,disc3,ndisc1" +
                        ",ndisc2,ndisc3,pot,nil_nett,ppn,nppn,dpp,jwb,idmatch,idlink,kd_dept,dept,subdept,no_spp,tgl_spp,kd_expd)" +
                        "values('" + idrec + "',{^" + tgl_po.ToShortDateString() + "},'" + no_po + "',{^" +
                        tgl_sj.ToShortDateString() + "},'" + no_sj + "',{^" + tgl_nota.ToShortDateString() + "},'" +
                        no_nota + "',{^" + tgl_terima.ToShortDateString() + "},'" +
                        kd_supp + "','" + supplier + "'," + nil_brutt + "," + disc2 + "," + disc2 + "," + disc3 + "," +
                        ndisc1 + "," + ndisc2 + "," + ndisc3 + "," + pot + "," + nil_nett + "," + ppn + "," + nppn + "," + dpp + "," + jwb + ",'" +
                        idmatch + "','" + idlink + "','" + kd_dept + "','" + dept + "','" + subdept + "','',{^},'')";
                    oComm.ExecuteNonQuery();
                    //progressBar1.Value = progressBar1.Value + 25;

                    oComm.CommandText = "Insert into " + direk + hpb_prod + "(idtr,tgl_sj,no_sj,tgl_terima,kd_supp,supplier,kd_expd,kd_dept,dept,subdept)" +
                        "values('" + idtr + "',{^" + tgl_sj.ToShortDateString() + "},'" + no_sj + "',{^" + tgl_terima.ToShortDateString() + "},'" +
                        kd_supp + "','" + supplier + "','','" + kd_dept + "','" + dept + "','" + subdept + "')"; ;
                    oComm.ExecuteNonQuery();
                    foreach (DataRow baris in dbgridd.Rows)
                    {
                        idtr = baris["IdRec"].ToString();
                        string material = baris["Material"].ToString().Trim();
                        string kdbrg = baris["KodeMaterial"].ToString().Trim();
                        string sat = baris["Satuan"].ToString().Trim();
                        double q_po = Convert.ToDouble(baris["QtyNota"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double q_sj = Convert.ToDouble(baris["QtyNota"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double q_nota = Convert.ToDouble(baris["QtyNota"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double q_terima = Convert.ToDouble(baris["QtyTerima"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double harga = Convert.ToDouble(baris["Harga"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double TotNota = Convert.ToDouble(baris["TotNota"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        string catatan = baris["Catatan"].ToString().Trim();
                        double kgbaik = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                        double kgsp = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                        double mtr_ke_kg = Convert.ToDouble(0, System.Globalization.CultureInfo.InvariantCulture);
                        string wkt = DateTime.Now.ToString("yyyyMMddHH:mm:ss");

                        oComm.CommandText = "Insert into " + direk + dtransb + "(idtr,idrec,kode_brg,nama_brg,satuan,q_po,q_sj,q_nota" +
                            ",q_terima,harga,nil_brut,tgl_sj,tgl_terima,disc1,disc2,disc3,ndisc1" +
                            ",ndisc2,ndisc3,pot,nil_nett,catatan,subdept,kgbaik,kgsp,mtr_ke_kg)" +
                            "values('" + idtr + "','SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS','" + kdbrg + "','" + material + "','" + sat + "'," +
                            q_po + "," + q_sj + "," + q_nota + "," + q_terima + "," + harga + "," +
                            TotNota + ",{^" + tgl_sj.ToShortDateString() + "},{^" + tgl_terima.ToShortDateString() + "}," +
                            disc1 + "," + disc2 + "," + disc3 + "," + ndisc1 + "," + ndisc2 + "," + ndisc3 + "," + pot + "," +
                            nil_nett + ",'" + catatan + "','" + subdept + "'," + kgbaik + "," + kgsp + "," + mtr_ke_kg + ")";
                        oComm.ExecuteNonQuery();

                        oComm.CommandText = "Insert into " + direk + dpb_prod + "(idtr,idrec,kode_brg,nama_brg,satuan,q_sj" +
                            ",q_terima,tgl_terima,catatan,subdept,kgbaik,mtr_ke_kg)" +
                            "values('" + idtr + "','SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS','" + kdbrg + "','" + material + "','" + sat + "'," +
                            q_sj + "," + q_terima + ",{^" + tgl_terima.ToShortDateString() + "},'" + catatan + "','" + subdept + "'," + kgbaik + "," +
                            mtr_ke_kg + ")";
                        oComm.ExecuteNonQuery();
                    }
                    u_komando();
                    DateTime endTime = DateTime.Now;
                    TimeSpan coba = endTime.Subtract(startTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error :\n" + ex);
            }
            finally
            {
                komando();
                dostampil();
                dbfkoneksi.Close();
            }
        }
        #endregion

        #region gudang
        public void vgudang_sql()
        {
            try
            {
                koneksi.Open();
                SqlDataReader myReader = null;
                SqlCommand cmdquery = new SqlCommand("vsp_gudang", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@KDGUDANG", ""));
                myReader = cmdquery.ExecuteReader();
                vgudang.Clear();
                dosgudang.Clear();
                vgudang.Load(myReader);
                foreach(DataRow tgudang in vgudang.Rows)
                {
                    dbfkoneksi.Open();
                    OleDbCommand oComm = dbfkoneksi.CreateCommand();
                    oComm.CommandText = "select kode,nama from " + direk + "gudang.dbf where kode='" + tgudang["Kode"].ToString() + "'";
                    dosgudang.Load(oComm.ExecuteReader());
                    dataGridView3.DataSource = dosgudang;
                    //MessageBox.Show("Kode Gudang " + tgudang["Kode"].ToString() + jml + " ditemukan");
                    if (dosgudang.Rows.Count <= 0)
                    {
                        oComm.CommandText = "Insert into " + direk + "gudang.dbf(kode,nama,idrec)" +
                            "values('" + tgudang["Kode"].ToString() + "','" + tgudang["Gudang"].ToString().Trim() +
                            "','SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS')";
                    }
                    else
                    {
                        oComm.CommandText = "Update " + direk + "gudang.dbf set nama='" + tgudang["Gudang"].ToString().Trim() +
                            "' where kode='" + tgudang["Kode"].ToString() + "'";
                    }
                    oComm.ExecuteNonQuery();
                    dbfkoneksi.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error :\n" + ex);
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void dgudang()
        {
            dbfkoneksi.Open();
            OleDbCommand oComm = dbfkoneksi.CreateCommand();
            string ceksql = "select kode,nama from " + direk + "gudang.dbf";       
            oComm.CommandText = ceksql;
            dosgudang.Clear();
            dosgudang.Load(oComm.ExecuteReader());
            dbfkoneksi.Close();
            dataGridView3.DataSource = dosgudang;
            int jml =dosgudang.Rows.Count;
            foreach (DataRow row in dosgudang.Rows)
            {
                kdgudang = row["kode"].ToString();
                string kodegud = kdgudang.Substring(0,2);
                nmgudang = row["nama"].ToString().Trim();
                koneksi.Open();
                SqlCommand cmdquery = new SqlCommand("psp_gudang", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@KDGUDANG", kdgudang));
                cmdquery.Parameters.Add(new SqlParameter("@KDCAB", kodegud));
                cmdquery.Parameters.Add(new SqlParameter("@NMGUD", nmgudang));
                cmdquery.ExecuteNonQuery();
                koneksi.Close();
            }
        }
        public void gudtampil()
        {
            dbfkoneksi.Open();
            OleDbCommand oComm = dbfkoneksi.CreateCommand();
            string ceksql = "select * from " + direk + gudang;
            oComm.CommandText = ceksql;
            DataTable oDs = new DataTable();
            oDs.Load(oComm.ExecuteReader());
            dbfkoneksi.Close();
            dataGridView4.DataSource = oDs;
            groupBox1.Text = "Data Gudang DBF";
        }
        public void gudangsql()
        {
            koneksi.Open();
            SqlDataReader myReader = null;
            SqlCommand cmdquery = new SqlCommand("vsp_gudang", koneksi);
            cmdquery.CommandType = CommandType.StoredProcedure;
            cmdquery.Parameters.Add(new SqlParameter("@KDGUDANG", ""));
            myReader = cmdquery.ExecuteReader();
            vgudang.Clear();
            vgudang.Load(myReader);
            dataGridView2.DataSource = vgudang;
            koneksi.Close();
        }
        #endregion

        #region stock material
        public void sqlmaterial(string kdm)
        {
            try
            {
                koneksi.Open();
                SqlDataReader myReader = null;
                SqlCommand cmdquery = new SqlCommand("vsp_material", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@KDM", kdm));
                myReader = cmdquery.ExecuteReader();
                dtmaterial.Clear();
                dtmaterial.Load(myReader);
                int a=0;
                foreach (DataRow tdmat in dtmaterial.Rows)
                {
                    a++;
                    string kdmat = tdmat["Kode"].ToString();
                    string jenisbhn= kdmat.Substring(3);
                    string nmmat = tdmat["Material"].ToString().Trim();
                    nmmat = gantistr(nmmat);
                    string sat = tdmat["Satuan"].ToString().Trim();
                    string isi = tdmat["Isi"].ToString();
                    double ks = Convert.ToDouble(tdmat["KgSatuan"]);
                    string sb = tdmat["SatuanBesar"].ToString();
                    string ctt = tdmat["Catatan"].ToString().Trim();
                    string pasif = tdmat["Pasif"].ToString();
                    string pm = tdmat["PartNum"].ToString().Trim();
                    double stdbrt = Convert.ToDouble(tdmat["StdBrt"]);
                    string nmpusat = tdmat["NamaMP"].ToString().Trim();
                    string unit = tdmat["UnitProduksi"].ToString().Trim();
                    string kddept = tdmat["KodeDep"].ToString().Trim();
                    string kddiv = tdmat["KodeDiv"].ToString().Trim();
                    string div = tdmat["Divisi"].ToString().Trim();
                    int bhnkimia;
                    if (kdmat.Substring(0, 3) == "JDI")
                    {
                        bhnkimia = 1;
                        goto lompat; 
                    }
                    else
                    {
                        bhnkimia = 0;
                    }
                    dbfkoneksi.Open();
                    OleDbCommand oComm = dbfkoneksi.CreateCommand();
                    oComm.CommandText = "select kode from " + direk + "stokbb.dbf where kode='" + jenisbhn + "'";
                    dosstok.Clear();
                    dosstok.Load(oComm.ExecuteReader());
                    int jml = dosstok.Rows.Count;
                    if (dosstok.Rows.Count > 0)
                    {
                        oComm.CommandText = "Update " + direk + "stokbb.dbf set nama='" + nmmat + "',satuan='" + sat + "',stdbdp=" + isi + ",stdvol=" + stdbrt + 
                            ",bhnkimia=" + bhnkimia + " where kode='" + jenisbhn + "'";
                        sqlerror = oComm.CommandText + " Update Proses Bahan Baku ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Tambah " + jenisbhn;
                        oComm.ExecuteNonQuery();
                    }
                    else
                    {
                        oComm.CommandText = "Insert into " + direk + "stokbb.dbf(kode,nama,satuan,ratio,stdbdp,stdvol,hrgbb" +
                            ",bypack,lwc,idrec,idmatch,kodebj,namabj,karet,karet1,karet2,piston,p_sr,k_a,id_trml,kdgol,kdproses,bhnkimia,bhntlg,kdpakekor,nmpakekor,id_cor,kd_klp)" +
                            "values('" + jenisbhn + "','" + nmmat + "','" + sat + "',0," + isi + "," + stdbrt + ",0,0,0" +
                            ",'SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS','0','','','','','','','','','','*','*'," + bhnkimia + ",0,'','','','')";
                        sqlerror = oComm.CommandText + " Insert Proses Bahan Baku ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Tambah " + jenisbhn;
                        oComm.ExecuteNonQuery();
                    }
                    dbfkoneksi.Close();
                    lompat:
                        label12.Text = "Termasuk Barang Jadi dengan Kode: " + jenisbhn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error di sqlmaterial :\n" + ex + "\n" + sqlerror);
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void sqlmaterial2(string kdm)
        {
            try
            {
                koneksi.Open();
                SqlDataReader myReader = null;
                SqlCommand cmdquery = new SqlCommand("vsp_material", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@KDM", kdm));
                myReader = cmdquery.ExecuteReader();
                dtmaterial.Clear();
                dtmaterial.Load(myReader);
                int a = 0;
                foreach (DataRow tdmat in dtmaterial.Rows)
                {
                    a++;
                    string kdmat = tdmat["Kode"].ToString();
                    string jenisbhn = kdmat.Substring(3);
                    string nmmat = tdmat["Material"].ToString().Trim();
                    nmmat = gantistr(nmmat);
                    string sat = tdmat["Satuan"].ToString().Trim();
                    string isi = tdmat["Isi"].ToString();
                    double kgsat = Convert.ToDouble(tdmat["KgSatuan"]);
                    string satbrs = tdmat["SatuanBesar"].ToString();
                    string ctt = tdmat["Catatan"].ToString().Trim();
                    string pasif = tdmat["Pasif"].ToString();
                    string pm = tdmat["PartNum"].ToString().Trim();
                    double stdbrt = Convert.ToDouble(tdmat["StdBrt"]);
                    string nmpusat = tdmat["NamaMP"].ToString().Trim();
                    string up = tdmat["UnitProduksi"].ToString().Trim();
                    string kddept = tdmat["KodeDep"].ToString().Trim();
                    string kddiv = tdmat["KodeDiv"].ToString().Trim();
                    string div = tdmat["Divisi"].ToString().Trim();
                    if (kdmat.Substring(0, 3) != "JDI")
                    {
                        goto lompat;
                    }
                    dbfkoneksi.Open();
                    OleDbCommand oComm = dbfkoneksi.CreateCommand();
                    oComm.CommandText = "select kode from " + direk + "stokjd.dbf where kode='" + jenisbhn + "'";
                    dosstok.Clear();
                    dosstok.Load(oComm.ExecuteReader());
                    int jml = dosstok.Rows.Count;
                    if (dosstok.Rows.Count > 0)
                    {
                        //kode,nama,nama_nota,part_num,kodebb,namabb,satuan,idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept
                        //oComm.CommandText = "Update " + direk + "stokjd.dbf set nama='" + nmmat + "',nama_nota='" + nmpusat + "',satuan='" + sat + "',nmdept='" + up + "'" +
                        //    ",part_num=" + pm + " where kode='" + jenisbhn + "'";
                        //sqlerror = oComm.CommandText + " Update Proses Barang Jadi ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Update " + jenisbhn;
                        //oComm.ExecuteNonQuery();
                    }
                    else
                    {
                        //kode,nama,nama_nota,part_num,kodebb,namabb,satuan,idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept
                        oComm.CommandText = "Insert into " + direk + "stokjd.dbf(kode,nama,nama_nota,part_num,kodebb,namabb,satuan" +
                            ",idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept)" +
                            "values('" + jenisbhn + "','" + nmmat + "','" + nmpusat + "','" + pm + "','','','" + sat + "'" +
                            ",'SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS',0,'0',0,'T','','',0,'*','','','" + kddept + "." + kddiv + "','" + up + "')";
                        oComm.ExecuteNonQuery();
                        sqlerror = oComm.CommandText + " Insert Proses Barang Jadi ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Tambah " + jenisbhn;
                    }
                    dbfkoneksi.Close();
                    lompat:
                        label12.Text = "Termasuk Bukan Barang Jadi dengan Kode: " + jenisbhn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error di sqlmaterial :\n" + ex + "\n" + sqlerror);
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void dosmaterial()
        {
            try
            {
                dbfkoneksi.Open();
                OleDbCommand oComm = dbfkoneksi.CreateCommand();
                string ceksql = "select * from " + direk + "stokbb.dbf";
                oComm.CommandText = ceksql;
                dosstok.Clear();
                dosstok.Load(oComm.ExecuteReader());
                dbfkoneksi.Close();
                dataGridView3.DataSource = dosstok;
                int jml = dosstok.Rows.Count;
                foreach (DataRow row in dosstok.Rows)
                {
                    //kode,nama,satuan,ratio,stdbdp,stdvol,hrgbb,bypack,lwc,idrec,idmatch,kodebj,namabj,
                    //karet,karet1,karet2,piston,p_sr,k_a,id_trml,kdgol,kdproses,bhnkimia,bhntlg,kdpakekor,nmpakekor,id_cor,kd_klp
                    string kdstok = row["kode"].ToString();
                    string nmstok = row["nama"].ToString();
                    string satuan = row["satuan"].ToString();
                    int ratio = Convert.ToInt32(row["ratio"]);
                    int stdbdp = Convert.ToInt32(row["stdbdp"].ToString());
                    double stdvol = Convert.ToDouble(row["stdvol"].ToString());
                    double hrgbb = Convert.ToDouble(row["hrgbb"].ToString());
                    double bypack = Convert.ToDouble(row["bypack"].ToString());
                    string lwc = row["lwc"].ToString();//logical F/T
                    string idrec2 = row["idrec"].ToString();
                    string idmatch = row["idmatch"].ToString();//0
                    string kodebj = row["kodebj"].ToString();
                    string namabj = row["namabj"].ToString();
                    string karet = row["karet"].ToString();
                    string karet1 = row["karet1"].ToString();
                    string karet2 = row["karet2"].ToString();
                    string piston = row["piston"].ToString();
                    string p_sr = row["p_sr"].ToString();
                    string k_a = row["k_a"].ToString();
                    string id_trml = row["id_trml"].ToString();
                    string kdgol = row["kdgol"].ToString();//*
                    string kdproses = row["kdproses"].ToString();//*
                    string bhnkimia = row["bhnkimia"].ToString();//logical F/T
                    string bhntlg = row["bhntlg"].ToString();//logical F/T
                    string kdpakekor = row["kdpakekor"].ToString();
                    string nmpakekor = row["nmpakekor"].ToString();
                    string id_cor = row["id_cor"].ToString();//logical Y/N
                    string kd_klp = row["kd_klp"].ToString();
                    koneksi.Open();
                    SqlCommand cmdquery = new SqlCommand("psp_material", koneksi);
                    cmdquery.CommandType = CommandType.StoredProcedure;
                    cmdquery.Parameters.Add(new SqlParameter("@KDM", kdstok));
                    cmdquery.Parameters.Add(new SqlParameter("@NMM", nmstok));
                    cmdquery.Parameters.Add(new SqlParameter("@SAT", satuan));
                    cmdquery.Parameters.Add(new SqlParameter("@ISI", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@KGSAT", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@SATB", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@CTT", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@PSF", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@PN", nmgudang));
                    cmdquery.Parameters.Add(new SqlParameter("@Jenis", "BKU"));
                    cmdquery.Parameters.Add(new SqlParameter("@KMA", bhnkimia));
                    cmdquery.ExecuteNonQuery();
                    koneksi.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error di dosmaterial :\n" + ex);
            }
            finally
            {
                koneksi.Close();
            }
        }
        static string gantistr(string p)
        {
            StringBuilder b = new StringBuilder(p);
            b.Replace("  ", string.Empty);
            b.Replace(Environment.NewLine, string.Empty);
            b.Replace("\\t", string.Empty);
            b.Replace(" {", "{");
            b.Replace(" :", ":");
            b.Replace(": ", ":");
            b.Replace(", ", ",");
            b.Replace("; ", ";");
            b.Replace(";}", "}");
            b.Replace("'", "`");
            return b.ToString();
        }
        public void sbbtampil()
        {
            try
            {
                dbfkoneksi.Open();
                OleDbCommand oComm = dbfkoneksi.CreateCommand();
                string ceksql = "select kode,nama,satuan,ratio,stdbdp,hrgbb,bhnkimia,bhntlg from " + direk + stokbb;
                oComm.CommandText = ceksql;
                DataTable oDs = new DataTable();
                oDs.Load(oComm.ExecuteReader());
                dbfkoneksi.Close();
                dataGridView4.DataSource = oDs;
                groupBox1.Text = "Data Stok Bahan Baku DBF";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error di Stok Bahan Baku :\n" + ex);
            }
        }
        public void sjdtampil()
        {
            dbfkoneksi.Open();
            OleDbCommand oComm = dbfkoneksi.CreateCommand();
            string ceksql = "select * from " + direk + stokjd;
            oComm.CommandText = ceksql;
            DataTable oDs = new DataTable();
            oDs.Load(oComm.ExecuteReader());
            dbfkoneksi.Close();
            dataGridView4.DataSource = oDs;
            groupBox1.Text = "Data Stok Barang Jadi DBF";
        }
        #endregion

        #region supplier
        public void sqlsupp(string kdm)
        {
            try
            {
                koneksi.Open();
                SqlDataReader myReader = null;
                SqlCommand cmdquery = new SqlCommand("vsp_supplier", koneksi);
                cmdquery.CommandType = CommandType.StoredProcedure;
                cmdquery.Parameters.Add(new SqlParameter("@KDM", kdm));
                myReader = cmdquery.ExecuteReader();
                dtmaterial.Clear();
                dtmaterial.Load(myReader);
                int a = 0;
                foreach (DataRow tdmat in dtmaterial.Rows)
                {
                    a++;
                    string kdmat = tdmat["Kode"].ToString();
                    string jenisbhn = kdmat.Substring(3);
                    string nmmat = tdmat["Material"].ToString().Trim();
                    nmmat = gantistr(nmmat);
                    string sat = tdmat["Satuan"].ToString().Trim();
                    string isi = tdmat["Isi"].ToString();
                    double kgsat = Convert.ToDouble(tdmat["KgSatuan"]);
                    string satbrs = tdmat["SatuanBesar"].ToString();
                    string ctt = tdmat["Catatan"].ToString().Trim();
                    string pasif = tdmat["Pasif"].ToString();
                    string pm = tdmat["PartNum"].ToString().Trim();
                    double stdbrt = Convert.ToDouble(tdmat["StdBrt"]);
                    string nmpusat = tdmat["NamaMP"].ToString().Trim();
                    string up = tdmat["UnitProduksi"].ToString().Trim();
                    string kddept = tdmat["KodeDep"].ToString().Trim();
                    string kddiv = tdmat["KodeDiv"].ToString().Trim();
                    string div = tdmat["Divisi"].ToString().Trim();
                    if (kdmat.Substring(0, 3) != "JDI")
                    {
                        goto lompat;
                    }
                    dbfkoneksi.Open();
                    OleDbCommand oComm = dbfkoneksi.CreateCommand();
                    oComm.CommandText = "select kode from " + direk + "stokjd.dbf where kode='" + jenisbhn + "'";
                    dosstok.Clear();
                    dosstok.Load(oComm.ExecuteReader());
                    int jml = dosstok.Rows.Count;
                    if (dosstok.Rows.Count > 0)
                    {
                        //kode,nama,nama_nota,part_num,kodebb,namabb,satuan,idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept
                        //oComm.CommandText = "Update " + direk + "stokjd.dbf set nama='" + nmmat + "',nama_nota='" + nmpusat + "',satuan='" + sat + "',nmdept='" + up + "'" +
                        //    ",part_num=" + pm + " where kode='" + jenisbhn + "'";
                        //sqlerror = oComm.CommandText + " Update Proses Barang Jadi ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Update " + jenisbhn;
                        //oComm.ExecuteNonQuery();
                    }
                    else
                    {
                        //kode,nama,nama_nota,part_num,kodebb,namabb,satuan,idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept
                        oComm.CommandText = "Insert into " + direk + "stokjd.dbf(kode,nama,nama_nota,part_num,kodebb,namabb,satuan" +
                            ",idrec,lstep,idmatch,ldnk,idrkt,idpack,id_ak,std_hpp,kdgol,kdklpbj,nmklpbj,kddept,nmdept)" +
                            "values('" + jenisbhn + "','" + nmmat + "','" + nmpusat + "','" + pm + "','','','" + sat + "'" +
                            ",'SAS" + DateTime.Now.ToString("yyyyMMddHH:mm:ss") + "SYS',0,'0',0,'T','','',0,'*','','','" + kddept + "." + kddiv + "','" + up + "')";
                        oComm.ExecuteNonQuery();
                        sqlerror = oComm.CommandText + " Insert Proses Barang Jadi ke " + a + " pada Kode Stok " + jenisbhn;
                        label12.Text = "Tambah " + jenisbhn;
                    }
                    dbfkoneksi.Close();
                lompat:
                    label12.Text = "Termasuk Bukan Barang Jadi dengan Kode: " + jenisbhn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error di sqlmaterial :\n" + ex + "\n" + sqlerror);
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void dossupp()
        {
            try
            {
                dbfkoneksi.Open();
                OleDbCommand oComm = dbfkoneksi.CreateCommand();
                string ceksql = "select kode,supplier,alamat,kota,produk from " + direk + "supplier.dbf";
                oComm.CommandText = ceksql;
                dtsuppd.Clear();
                dtsuppd.Load(oComm.ExecuteReader());
                dbfkoneksi.Close();
                dataGridView3.DataSource = dtsuppd;
                int jml = dtsuppd.Rows.Count;
                foreach (DataRow row in dtsuppd.Rows)
                {
                    string kdsupp = row["kode"].ToString().Trim();
                    string nmsupp = row["supplier"].ToString().Trim();
                    string alamat = row["alamat"].ToString().Trim();
                    string kota = row["kota"].ToString().Trim();
                    string produk = row["produk"].ToString().Trim();
                    koneksi.Open();
                    SqlCommand cmdquery = new SqlCommand("psp_supplier", koneksi);
                    cmdquery.CommandType = CommandType.StoredProcedure;
                    cmdquery.Parameters.Add(new SqlParameter("@KD", kdsupp));
                    cmdquery.Parameters.Add(new SqlParameter("@NM", nmsupp));
                    cmdquery.Parameters.Add(new SqlParameter("@ALM", alamat));
                    cmdquery.Parameters.Add(new SqlParameter("@Kota", kota));
                    cmdquery.Parameters.Add(new SqlParameter("@Prd", produk));
                    cmdquery.ExecuteNonQuery();
                    koneksi.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error :\n" + ex);
            }
            finally
            {
                koneksi.Close();
            }
        }
        #endregion

        public void lempar()
        {
            DateTime skrg = DateTime.Today;
            dbfkoneksi.Open();
            using (OleDbCommand oComm = dbfkoneksi.CreateCommand()) 
            try
            {
                DateTime myDate = DateTime.Now;
                label4.Text = "Input data Jurnal Tanggal Hari ini : " + DateTime.Now.ToShortDateString();
                oComm.CommandText = "Insert into " + direk + jurnal + "(tanggal,referensi,no_perk,keterangan,jumlah,idrec,ctanggal,id_adjust,kdcabang,idtrdrlain,kdcostcntr,nmcostcntr)" +
                    "values({^" + myDate.ToShortDateString() + "},'" + commonTextBox1.Text + "','" + commonTextBox2.Text + "','Coba Jurnal'," + commonTextBox3.Text + ",'GL" + skrg + "','','','017','','','')"; ;
                int efek = oComm.ExecuteNonQuery();
                //MessageBox.Show(this, "Simpan ke " + direk3 + " jumlah " + efek + " baris.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error :\n" + ex);
            }
            finally
            {
                dbfkoneksi.Close();
            }
        }

        public string DirProject()
        {
            string DirDebug = System.IO.Directory.GetCurrentDirectory();
            string DirProject = DirDebug;

            for (int counter_slash = 0; counter_slash < 4; counter_slash++)
            {
                DirProject = DirProject.Substring(0, DirProject.LastIndexOf(@"\"));
            }

            return DirProject;
        }

        public void UploadBeli(DataTable dt)
        {
            string Physical = "C:\\Temp\\JOURNAL.zip";// Lookup.DbfUpload + "\\" + "JOURNAL.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("TANGGAL", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("REFERENSI", "referensi", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("NO_PERK", "no_perk", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("KETERANGAN", "keterangan", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("JUMLAH", "jumlah", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("IDREC", "idrec", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("CTANGGAL", "ctanggal", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("ID_ADJUST", "id_adjust", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("KDCABANG", "kdcabang", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("IDTRDRLAIN", "idtrdrlain", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("KDCOSTCNTR", "kdcostcntr", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("NMCOSTCNTR", "nmcostcntr", Foxpro.enFoxproTypes.Char, 50));
            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("IDREC", "IDREC"));
            progressBar1.ResetText();
            //progressBar1.Visible = true;
            Foxpro.WriteFile(Lookup.DbfUpload, "JOURNAL", fields, dt, progressBar1, index);
            //progressBar1.Visible = false;
        }

        private void ZipFile(List<string> files)
        {
            string fileZipName = "C:\\Temp\\JOURNAL.zip";//Lookup.DbfUpload + 
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }
            Zip.ZipFiles(files, fileZipName);
            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idrec = (string)dataGridView2.SelectedCells[0].OwningRow.Cells["Idrec"].Value;
            komandoD();
            commonTextBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["NoPo"].Value.ToString();
            commonTextBox2.Text = (string)dataGridView2.Rows[e.RowIndex].Cells["NoNota"].Value;
            commonTextBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["TglPo"].Value.ToString();
            //commonTextBox3.Text = (string)dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;//sesuai koordinat baris kolom cursor
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tulistxt();
            rfresh++;
            if (rfresh > 30)
            {
                if (dbgrid.Rows.Count > 0)
                {
                    komando();
                }         
                startimer();
            }
            else 
            {       
                linkLabel1.Text = "To GL DOS Reload dalam " + Convert.ToSingle(rfresh.ToString()) + " lagi.";
            }
            //int makspb = Convert.ToInt32(progressBar1.Maximum.ToString());
            //progressBar1.Value = makspb;
            //label12.Text = progressBar1.Value.ToString() + "%";
            //progressBar1.Value++;
            //if (this.progressBar1.Value == makspb)
            //{
            //    progressBar1.Value = 0;
            //}
        }

        private static FileStream fs = new FileStream(@"c:\temp\togldos.txt", FileMode.OpenOrCreate, FileAccess.Write);
        private static StreamWriter m_streamWriter = new StreamWriter(fs);
        private void startimer()
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;            
            rfresh = 0;
            pictureBox1.Visible = false;
            komando();
            //this.WindowState = FormWindowState.Minimized;
        }
        private void stoptimer()
        {
            timer1.Enabled = false;
        }
        private void buattxt()
        {
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(" File Write Operation Starts : ");
            m_streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.WriteLine(" ===================================== \n");
            m_streamWriter.Flush();
        }
        private void tulistxt()
        {
            m_streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.Flush();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
        
        #region untuk tray icon
        private System.Windows.Forms.MenuItem m1, m2 = new MenuItem();

        private void m1_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.Hide();
        }

        private void m2_Click(object sender, System.EventArgs e)
        {
            DisposetheWindow(true);
            notifyicon1.Dispose();
            stoptimer();
            Application.Exit();
        }   
        #endregion

        private void pembelianToGLDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dbgrid.Rows.Count > 0)
            {
                try
                {
                    startimer();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi Error :\n" + ex);
                }
            }
            else
            {
                stoptimer();
                MessageBox.Show("Tidak ada Data Pembelian Baru yang akan di upload");
            }
            dostampil();
            groupBox1.Visible = true;
            dataGridView4.Visible = false;
            dataGridView1.Visible = true;
            cmdMJU.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toGudangDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgudang();
            label5.Text = "Data Gudang di SQL Server";
            label11.Text = "Data Gudang di DBF";
        }

        private void toGudangSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vgudang_sql();
        }

        private void materialKeStokBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlmaterial("");
        }

        private void keStokBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlmaterial2("");
        }

        private void previewJournalDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            jutampil();
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            cmdMJU.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dostampil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startimer();
            button3.Visible = false;
        }

        private void cmdMJU_Click(object sender, EventArgs e)
        {
            addbeli();
        }

        private void previewGudangDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            gudtampil();
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            cmdMJU.Enabled = false;
        }

        private void previewStokBahanBakuDBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            sbbtampil();
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            cmdMJU.Enabled = false;
        }

        private void stokBarangJadiDBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            sjdtampil();
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            cmdMJU.Enabled = false;
        }

        private void toSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dossupp();
        }

        /*
        private void ProsesUploadInvFOX()
        {
            string FileName1 = "jurnal";
            string FileName2 = "jurnal";
            //string no_PL = this.GVHeader.SelectedCells[0].OwningRow.Cells["NoPL"].Value.ToString();
            //Guid RowIdH = (Guid)this.GVHeader.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
            //string nopl_inv = no_PL.Replace("/", ".");
            //string FileZipInv = nopl_inv;
            ProgressBar DetailprogressBar = new ProgressBar();

            PopulateDataINV();

            List<string> filedbf = new List<string>();
            filedbf.Add(Application.StartupPath + "\\" + FileName1 + ".dbf");
            filedbf.Add(Application.StartupPath + "\\" + FileName1 + ".cdx");
            filedbf.Add(Application.StartupPath + "\\" + FileName2 + ".dbf");
            filedbf.Add(Application.StartupPath + "\\" + FileName2 + ".cdx");

            foreach (string var in filedbf)
            {
                if (File.Exists(var))
                {
                    File.Delete(var);
                }
            }

            //tanggal,referensi,no_perk,keterangan,jumlah,idrec,ctanggal,id_adjust,kdcabang,idtrdrlain,kdcostcntr,nmcostcntr
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("referensi", "referensi", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("ctanggal", "ctanggal", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("id_adjust", "id_adjust", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("kdcabang", "kdcabang", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("idtrdrlain", "idtrdrlain", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("kdcostcntr", "kdcostcntr", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("nmcostcntr", "nmcostcntr", Foxpro.enFoxproTypes.Char, 10));


            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idrec", "idrec"));

            Foxpro.WriteFile(Application.StartupPath, FileName1, fields, jurnalDB, DetailprogressBar, index);

            fields.Clear();
            index.Clear();

            ZipFile(filedbf, FileZipInv);

            updateUploadDateInv(RowIdH);

            RefreshRowDataGridHeader(RowIdH);
        }

        private void PopulateDataINV()
        {

            DataTable dtH = dtHeader.Copy();
            dtDIv = dtDetail.Copy();
            Guid rowID_ = (Guid)this.GVHeader.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
            dtH.DefaultView.RowFilter = "RowID='" + rowID_.ToString() + "'";
            dtHD.Rows.Clear();
            dtDIv.Rows.Clear();


            string RecordID_ = string.Empty;
            DataTable dt = new DataTable();
            foreach (DataRowView dv in dtH.DefaultView)
            {
                rowID_ = (Guid)dv["RowID"];

                RecordID_ = dv["RecordID"].ToString();
                DataRow drw = dtHD.NewRow();
                drw["RecordID"] = dv["RecordID"];
                drw["NoInvoice"] = dv["NoInvoice"];
                drw["TglInvoice"] = dv["TglInvoice"];
                drw["VendorID"] = dv["VendorID"];
                dtHD.Rows.Add(drw);



                foreach (DataRow dr in dtDetail.Rows)
                {
                    DataRow drd = dtDIv.NewRow();
                    drd["RecordID"] = dr["RecordID"];
                    drd["HRecordID"] = RecordID_;
                    drd["KodeBarang"] = dr["KodeBarang"];
                    drd["NamaBarang"] = dr["NamaBarang"];
                    drd["Satuan"] = dr["Satuan"];
                    drd["QtyTerima"] = dr["QtyTerima"];
                    drd["Harga"] = dr["Harga"];
                    dtDIv.Rows.Add(drd);
                }
            }

        }
        */
    }
}
