﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    public partial class LookupToko : UserControl
    {
        public event EventHandler SelectData;

        Guid  _rowID;
        string _tokoID;
        string _alamat;
        string _kota;
        string _WilID;
        string _lastNamaToko = "";
        int _hrSales, _hrKirim;
        double _Plafon;
        string _Catatan=string.Empty;
        string _Grade = string.Empty;

        public Guid RowID
        {
            get
            {
                return _rowID;
            }
            set
            {
                _rowID = value;
            }
        }

        public string Catatan
        {
            get { return _Catatan; }
            set { _Catatan = value; }
        }

        public string Grade
        {
            get { return _Grade; }
            set { _Grade = value; }
        }

        public string WilID
        {
            get { return _WilID; }
            set { _WilID = value; }
        }

        public double Plafon
        {
            get { return _Plafon; }
            set { _Plafon = value; }
        }

        public string KodeToko
        {
            get
            {
                return txtLookupCode.Text;
            }
            set
            {
                txtLookupCode.Text = value;
            }
        }

        public string NamaToko
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
            }
        }

        public string TokoID
        {
            get
            {
                return _tokoID;
            }
            set
            {
                _tokoID = value;
            }
        }

        public string Alamat
        {
            get 
            {
                return _alamat;
            }
            set 
            {
                _alamat = value;
            }
        }

        public string Kota
        {
            get 
            {
                return _kota;
            }
            set
            { 
                _kota = value;
            }
        }

        public int HariSales
        {
            get
            {
                return _hrSales;
            }
            set
            {
                _hrSales = value;
            }
        }

        public int HariKirim
        {
            get
            {
                return _hrKirim;
            }
            set
            {
                _hrKirim = value;
            }
        }


        public LookupToko()
        {
            InitializeComponent();
        }

        public void SetNamaToko(string nama)
        {
            txtLookupName.Text = nama;
            _lastNamaToko = nama;
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13 && _lastNamaToko.Trim() != txtLookupName.Text.Trim())
            //{
            //    if (txtLookupName.Text != "")
            //    {
            //        try
            //        {
            //            using (Database db = new Database())
            //            {
            //                DataTable dt = new DataTable();

            //                db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
            //                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
            //                dt = db.Commands[0].ExecuteDataTable();
            //                if (dt.Rows.Count == 1)
            //                {
            //                    txtLookupName.Text = Tools.isNull( dt.Rows[0]["NamaToko"],"").ToString();                                
            //                    txtLookupCode.Text = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
            //                    _lastNamaToko = txtLookupCode.Text;
            //                    _rowID = (Guid)dt.Rows[0]["RowID"];
            //                    _tokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
            //                    _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            //                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
            //                    if (this.SelectData != null)
            //                    {
            //                        this.SelectData(this, new EventArgs());
            //                    }
            //                }
            //                else
            //                {
            //                    ShowDialogForm(txtLookupName.Text, dt );
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //    else
            //    {

            //        Clear();
            //    }
            //}
        }

        private void ShowDialogForm()
        {
            frmTokoLookUp ifrmDialog = new frmTokoLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmTokoLookUp ifrmDialog = new frmTokoLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult(frmTokoLookUp dialogForm)
        {
            _rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.namaToko;
            _lastNamaToko = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.kodeToko;
            _tokoID = dialogForm.TokoId;
            _alamat = dialogForm.alamat;
            _kota = dialogForm.kota;
            _hrKirim = dialogForm.hariKirim;
            _hrSales = dialogForm.hariSales;
            _Catatan = dialogForm.catatan;
            _Grade = dialogForm.grade;
            txtLookupName.Focus();
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _lastNamaToko = txtLookupName.Text;
            txtLookupCode.Text = "";
            _tokoID = "";
            _alamat = "";
            _kota = "";
            _hrKirim = 0;
            _hrSales = 0;
            _WilID = string.Empty;
            _Plafon = 0;
            _Catatan = string.Empty;
            _Grade = string.Empty;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }


        public void ClearDataLookUp()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _lastNamaToko = txtLookupName.Text;
            txtLookupCode.Text = "";
            _tokoID = "";
            _alamat = "";
            _kota = "";
            _hrKirim = 0;
            _hrSales = 0;
            _WilID = string.Empty;
            _Plafon = 0;
            _Catatan = string.Empty;
            _Grade = string.Empty;
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                SearchToko();
            }
        
        }

        public void SearchToko()
        {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
                        _lastNamaToko = txtLookupCode.Text;
                        _rowID = (Guid)dt.Rows[0]["RowID"];
                        _tokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                        _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _hrKirim = int.Parse(Tools.isNull(dt.Rows[0]["HariKirim"], "").ToString());
                        _hrSales = int.Parse(Tools.isNull(dt.Rows[0]["HariSales"], "").ToString()); 
                        _Plafon = double.Parse(Tools.isNull(dt.Rows[0]["HariSales"], "0").ToString());
                        _WilID = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                        _Grade = Tools.isNull(dt.Rows[0]["Grade"], "").ToString();
                        _Catatan = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtLookupName.Text, dt);
                    }
                }
            
 
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (_lastNamaToko.Trim() != txtLookupName.Text.Trim())
            {
                if (txtLookupName.Text != "")
                {
                    SearchToko();
                }
                else
                {
                    Clear();
                }
            }
        }
    }
}
