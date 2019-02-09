using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Showroom.Controls
{
    public partial class lookUpJenisMotor : UserControl
    {
        public event EventHandler SelectData;

        string _jenisMotor="";
        string _tahun="";
        double _harga=0;
        Guid _RowID=Guid.Empty;


        public string JenisMotor
        {
            get
            {
                return _jenisMotor;
            }
            set
            {
                txtJenisMotor.Text = value;
                _jenisMotor=value;
            }
        }

        public string Tahun
        {
            get
            {
                return _tahun;
            }
            set
            {
                _tahun = value;
            }
        }

        public Double Harga
        {
            get
            {
                return _harga;
            }
            set
            {
                _harga = value;
            }
        }

        public Guid RowID
        {
            get
            {
                return _RowID;
            }
            set
            {
                _RowID=value;
            }
        }
        

        public lookUpJenisMotor()
        {
            InitializeComponent();
        }

        private void txtNamaMotor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtJenisMotor.Text != "")
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();


                        db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@Arg", SqlDbType.VarChar, txtJenisMotor.Text));
                        dt = db.Commands[0].ExecuteDataTable();


                        if (dt.Rows.Count == 1)
                        {
                            JenisMotor = Tools.isNull(dt.Rows[0]["JenisMotor"], "").ToString();
                            Tahun = Tools.isNull(dt.Rows[0]["Tahun"], "").ToString();
                            Harga = Double.Parse(Tools.isNull(dt.Rows[0]["Harga"], "0").ToString());
                            RowID = (Guid)(dt.Rows[0]["Tahun"]);
                            if (this.SelectData != null)
                            {
                                this.SelectData(this, new EventArgs());
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtJenisMotor.Text, dt);
                        }
                    }


                }
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmLookUpJenisMotor ifrmDialog = new frmLookUpJenisMotor(dt, searchArg);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmLookUpJenisMotor dialogForm)
        {

            JenisMotor = dialogForm._JenisMotor;
            Tahun = dialogForm._Tahun;
            Harga = dialogForm._Harga;
            RowID = dialogForm._RowID;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            JenisMotor = "";
            Tahun = "";
            Harga = 0;
            RowID = Guid.Empty;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();


                db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@Arg", SqlDbType.VarChar, txtJenisMotor.Text));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count == 1)
                {
                    JenisMotor = Tools.isNull(dt.Rows[0]["JenisMotor"], "").ToString();
                    Tahun = Tools.isNull(dt.Rows[0]["Tahun"], "").ToString();
                    Harga = Double.Parse(Tools.isNull(dt.Rows[0]["Harga"], "0").ToString());
                    RowID = (Guid)(dt.Rows[0]["RowID"]);
                    if (this.SelectData != null)
                    {
                        this.SelectData(this, new EventArgs());
                    }
                }
                else
                {
                    ShowDialogForm(txtJenisMotor.Text, dt);
                }
            }
        }
    }
}
