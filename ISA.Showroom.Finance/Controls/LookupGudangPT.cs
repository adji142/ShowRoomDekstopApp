﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Finance.Controls;

namespace ISA.Showroom.Finance.Controls
{
    public partial class LookupGudangPT : UserControl
    {
        public event EventHandler SelectData;

        string _kodeCabang;
        bool _bypassCheckInitCab = false;

        public string GudangID
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

        public string NamaGudang
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

        public string KodeCabang
        {
            get
            {
                return _kodeCabang;
            }
            set
            {
                _kodeCabang = value;
            }
        }

        [Browsable(true), DefaultValue (false)]
        public bool ByPassCheckInitCab
        {
            get
            {
                return _bypassCheckInitCab;
            }
            set
            {
                _bypassCheckInitCab = value;
            }
        }

        public LookupGudangPT()
        {
            InitializeComponent();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
                {
                    if (txtLookupName.Text == GlobalVar.CabangID && _bypassCheckInitCab)
                    {
                        return;
                    }
                    using (Database db = new Database())
                    {
                        DataTable dtStok = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                        if (dtStok.Rows.Count == 1)
                        {
                            txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaGudang"], "").ToString();
                            txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["GudangID"], "").ToString();
                            if (this.SelectData != null)
                            {
                                this.SelectData(this, new EventArgs());
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtLookupName.Text, dtStok);
                        }
                    }
                    
                                
                }
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm()
        {
            frmGudangPTLookup ifrmDialog = new frmGudangPTLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmGudangPTLookup ifrmDialog = new frmGudangPTLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmGudangPTLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.namaGudang;            
            txtLookupCode.Text = dialogForm.gudangId;
            _kodeCabang = dialogForm.kodeCabang;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeCabang = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }
    }
}
