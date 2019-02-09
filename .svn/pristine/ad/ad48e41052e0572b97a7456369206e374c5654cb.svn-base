using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Controls
{
    public partial class PartnerComboBox : ComboBox
    {
        public PartnerComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Partner_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                
                dt.DefaultView.Sort = "Display ASC";
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                this.DataSource = dt.DefaultView;
                this.DisplayMember = "Display";
                this.ValueMember = "KodeTransaksi";
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public string PartnerID
        {
            get
            {
                string id = "";
                if (this.SelectedIndex >= 0)
                    id = this.SelectedValue.ToString();
                return id;
            }

            set
            {
                this.SelectedValue = value;
            }
        }

    }
}
