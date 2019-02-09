using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.DKN
{
    public partial class frmDownloadDKNUpdate2 : ISA.Controls.BaseForm
    {
        enum enumCaption { Import, Input }
        enumCaption _capt = enumCaption.Import;
        public frmDownloadDKNUpdate2()
        {
            InitializeComponent();
        }

        private void frmDownloadDKNUpdate2_Load(object sender, EventArgs e)
        {
            cmdConvert.Text = _capt.ToString();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

        }

        private void cmdConvert_Click(object sender, EventArgs e)
        {
            switch (_capt)
            {
                case enumCaption.Import:
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Uraian", typeof(System.String));
                        dt.Columns.Add("Nominal", typeof(System.Double));
                        dt.Columns.Add("Cabang", typeof(System.String));
                        string s = txtDetail.Text;
                        string[] tbl = s.Split((char)'\n');
                        foreach (string brs in tbl)
                        {
                            string[] itm = brs.Split((char)'\t');
                            if (itm.Length > 2)
                            {
                                try
                                {
                                    DataRow dr = dt.Rows.Add();
                                    dr["Uraian"] = itm[0].ToString();
                                    dr["Nominal"] = double.Parse(itm[itm.Length - 2].ToString());
                                    dr["Cabang"] = itm[itm.Length - 1].ToString();
                                }
                                catch { }
                            }
                        }
                        customGridView1.DataSource = dt;
                        customGridView1.ReadOnly = false;
                        _capt = enumCaption.Input;
                    }
                    break;
                case enumCaption.Input:
                    {
                        _capt = enumCaption.Import;
                    } break;
                default: break;
            }
            toggleDetail();
        }

        void toggleDetail()
        {
            switch (_capt)
            {
                case enumCaption.Import: {
                    cmdConvert.Text = _capt.ToString();
                    txtDetail.Visible = true;
                    customGridView1.Visible = false;
                } break;
                case enumCaption.Input: {
                    cmdConvert.Text = _capt.ToString();
                    txtDetail.Visible = false;
                    customGridView1.Visible = true;
                } break;
                default: break;
            }
        }
    }
}
