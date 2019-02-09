using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;

namespace ISA.Showroom.Administrasi
{
    public partial class frmIdentitasPerusahaan : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        
        enumFormMode formMode;

        DataTable dt;

        Guid _rowID;
        
        public frmIdentitasPerusahaan()
        {
            InitializeComponent();
        }

        private void frmIdentitasPerusahaan_Load(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                DataTable dtprop = FillComboBox.DBGetProvinsi(Guid.Empty);
                dtprop.DefaultView.Sort = "Nama ASC";
                cboProvinsi.DisplayMember = "Nama";
                cboProvinsi.ValueMember = "RowID";
                cboProvinsi.DataSource = dtprop.DefaultView;

                if (dt.Rows.Count > 0)
                {
                    DataTable dtKota = FillComboBox.DBGetStateAll(Guid.Empty, "", Guid.Empty, Tools.isNull(dt.Rows[0]["Kota"], "").ToString(), Guid.Empty, "", Guid.Empty, "");
                    formMode = enumFormMode.Update;
                    _rowID = (Guid)(dt.Rows[0]["RowID"]);
                    txtCabangID.Text = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    txtInitPerusahaan.Text = Tools.isNull(dt.Rows[0]["InitPerusahaan"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    cboProvinsi.Text = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString();
                    cboKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtNegara.Text = Tools.isNull(dt.Rows[0]["Negara"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtNPWP.Text = Tools.isNull(dt.Rows[0]["NPWP"], "").ToString();
                    txtEmail.Text = Tools.isNull(dt.Rows[0]["Email"], "").ToString();                    
                    txtKodePos.Text = Tools.isNull(dt.Rows[0]["KodePos"], "").ToString();
                    txtFax.Text = Tools.isNull(dt.Rows[0]["Fax"], "").ToString();
                    txtWebsite.Text = Tools.isNull(dt.Rows[0]["Website"], "").ToString();
                    txtPenanggungJawab.Text = Tools.isNull(dt.Rows[0]["PenanggungJawab"], "").ToString();
                    txtNoKTPPJ.Text = Tools.isNull(dt.Rows[0]["NoKTP_PJ"], "").ToString();
                    txtJabatan.Text = Tools.isNull(dt.Rows[0]["Jabatan"], "").ToString();
                    txtDirektur.Text = Tools.isNull(dt.Rows[0]["Direktur"], "").ToString();
                }
                else
                {
                    formMode = enumFormMode.New;
                    txtCabangID.Text = "";
                    txtInitPerusahaan.Text = "";
                    txtNama.Text = "";
                    txtAlamat.Text = "";
                    txtNegara.Text = "";
                    txtTelp.Text = "";
                    txtNPWP.Text = "";
                    txtEmail.Text = "";
                    txtKodePos.Text = "";
                    txtFax.Text = "";
                    txtWebsite.Text = "";
                    txtPenanggungJawab.Text = "";
                    txtNoKTPPJ.Text = "";
                    txtJabatan.Text = "";
                    txtDirektur.Text = "";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_INSERT"));

                            _rowID = Guid.NewGuid();

                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, txtCabangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cboKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@npwp", SqlDbType.VarChar, txtNPWP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, cboProvinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoKTP_PJ", SqlDbType.VarChar, txtNoKTPPJ.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jabatan", SqlDbType.VarChar, txtJabatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Direktur", SqlDbType.VarChar, txtDirektur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_UPDATE"));

                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, txtCabangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cboKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@npwp", SqlDbType.VarChar, txtNPWP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, cboProvinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoKTP_PJ", SqlDbType.VarChar, txtNoKTPPJ.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jabatan", SqlDbType.VarChar, txtJabatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Direktur", SqlDbType.VarChar, txtDirektur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboProvinsi.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKota.DisplayMember = "Nama";
                cboKota.ValueMember = "RowID";
                cboKota.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtTelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals(' ')) && !(e.KeyChar.Equals('(')) && !(e.KeyChar.Equals(')')) && !(e.KeyChar.Equals('-')))
            {
                e.Handled = true;
            }
        }

        private void txtNPWP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals('.')))
            {
                e.Handled = true;
            }
        }

        private void txtKodePos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals(' ')) && !(e.KeyChar.Equals('(')) && !(e.KeyChar.Equals(')')) && !(e.KeyChar.Equals('-')))
            {
                e.Handled = true;
            }
        }
    }
}
