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
using System.Globalization;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.DataTemplates;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPerubahanBBNBrowse : ISA.Controls.BaseForm
    {
        public frmPerubahanBBNBrowse()
        {
            InitializeComponent();
        }

        private void frmPerubahanBBNBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDateTime_RealTime;
            rangeDateBox1.ToDate = GlobalVar.GetServerDateTime_RealTime;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            if(rangeDateBox1.FromDate > rangeDateBox1.ToDate)
            {
                DateTime temp = rangeDateBox1.FromDate.Value;
                rangeDateBox1.FromDate = rangeDateBox1.ToDate.Value;
                rangeDateBox1.ToDate = temp;
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_UbahBBN"));
                if(rangeDateBox1.FromDate.HasValue)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value ));
                }
                
                if(rangeDateBox1.ToDate.HasValue)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value ));
                }

                if(String.IsNullOrEmpty(txtKotaIdt.Text))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@KotaIdt", SqlDbType.VarChar, txtKotaIdt.Text.Trim()));
                }

                if(String.IsNullOrEmpty(txtTahun.Text))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, txtTahun.GetIntValue));
                }
                
                if(String.IsNullOrEmpty(txtTipeMotor.Text))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@TipeMotor", SqlDbType.VarChar, txtTipeMotor.Text.Trim()));
                }

                if (String.IsNullOrEmpty(txtNoTrans.Text))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTrans.Text));
                }

                if (String.IsNullOrEmpty(txtNoBukti.Text))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                }
                
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID ));
                dgPenjualan.DataSource = db.Commands[0].ExecuteDataTable(); 
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (dgPenjualan.Rows.Count > 0)
            {
               // if (Convert.ToDateTime
                if (MessageBox.Show("Data - data yang tertampil di atas akan diubah BBN nya menjadi " + txtBBN.Text + ", Harga Kosong akan menyesuaikan, yakin melanjutkan proses ini?", Messages.Question.AskSave,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = 0;
                    int counterdb = 0;
                    Database db = new Database();
                    try
                    {
                        for (i = 0; i < dgPenjualan.Rows.Count; i++)
                        {
                            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_UbahBBN"));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, new Guid(Tools.isNull(dgPenjualan.Rows[i].Cells["PenjRowID"].Value.ToString(), Guid.Empty).ToString()) ));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@BBNBaru", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dgPenjualan.Rows[i].Cells["BBNBaru"].Value.ToString(), "0").ToString())));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadiBaru", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dgPenjualan.Rows[i].Cells["HargaJadiBaru"].Value.ToString(), "0").ToString()) ));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            counterdb++;
                        }

                        db.BeginTransaction();
                        int looper = 0;
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        MessageBox.Show("Data berhasil diproses");
                        dgPenjualan.DataSource = new DataTable();
                    }
                    catch(Exception ex)
                    {
                        db.RollbackTransaction();
                        MessageBox.Show("Terjadi Error :" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tidak ada data yg dapat diproses!");
            }
        }

        private void txtBBN_Leave(object sender, EventArgs e)
        {
            urusBBNBaru();
        }

        private void urusBBNBaru()
        {
            int i = 0;
            Double BBNLama = 0, HargaJadiLama = 0;
            Double BBNBaru = 0, HargaJadiBaru = 0;
            Double SelisihBBN = 0;
            BBNBaru = txtBBN.GetDoubleValue;

            for (i = 0; i < dgPenjualan.Rows.Count; i++ )
            {   
                BBNLama = Convert.ToDouble(Tools.isNull(dgPenjualan.Rows[i].Cells["BBN"].Value.ToString(), "0").ToString());
                HargaJadiLama = Convert.ToDouble(Tools.isNull(dgPenjualan.Rows[i].Cells["HargaJadi"].Value.ToString(), "0").ToString());
                
                SelisihBBN = BBNLama - BBNBaru;
                HargaJadiBaru = HargaJadiLama + SelisihBBN;

                dgPenjualan.Rows[i].Cells["BBNBaru"].Value = txtBBN.GetDoubleValue;
                dgPenjualan.Rows[i].Cells["HargaJadiBaru"].Value = HargaJadiBaru;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
