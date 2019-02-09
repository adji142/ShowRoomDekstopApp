using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Controls
{
    public partial class frmTokoLookUp : ISA.Controls.BaseForm
    {
        Guid _rowID;
        string _tokoID;
        string _namaToko;
        string _kodeToko;
        string _alamat;
        string _kota;
        string _WilID;
        double _Plafon;
        string _grade;
        string _catatan;
        int _hrSales, _hrKirim;
               
        public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }
        
        public string catatan
        {
            get { return _catatan; }
            set { _catatan = value; }
        }

        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }


        public string wilID
        {
            get { return _WilID; }
            set { _WilID = value; }
        }

        public double plafon
        {
            get { return _Plafon; }
            set { _Plafon = value; }
        }


        public string TokoId
        {
            get
            {
                return _tokoID;
            }
        }

        public string namaToko
        {
            get
            {
                return _namaToko;
            }
        }

        public string kodeToko
        {
            get
            {
                return _kodeToko;
            }
        }

        public string alamat
        {
            get
            {
                return _alamat;
            }
        }

        public string kota
        {
            get
            {
                return _kota;
            }
        }

        public int hariSales
        {
            get
            {
                return _hrSales;
            }
        }

        public int hariKirim
        {
            get
            {
                return _hrKirim;
            }
        }


        public frmTokoLookUp()
        {
            InitializeComponent();
        }

        public frmTokoLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dt.DefaultView.Sort = "NamaToko";
            dataGridView1.DataSource = dt.DefaultView;            
        }

        private void frmTokoLookUp_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "NamaToko";
                    dataGridView1.DataSource = dt.DefaultView;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {                
            if (dataGridView1.SelectedCells.Count == 1)
            {                
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                _rowID = new Guid( dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _tokoID = dataGridView1.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
                _namaToko = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                _kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
                _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                _hrSales = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["HariSales"].Value.ToString());
                _hrKirim = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["HariKirim"].Value.ToString());
                _Plafon = double.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["HariSales"].Value.ToString() );
                _WilID = dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString();
                _grade = dataGridView1.SelectedCells[0].OwningRow.Cells["Grade"].Value.ToString();
                _catatan = dataGridView1.SelectedCells[0].OwningRow.Cells["Catatan"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }


    }
}
