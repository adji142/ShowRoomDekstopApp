using System;
using System.Collections.Generic;
using System.Data;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Class
{
    public class FillComboBox  
    { 
        public void fillComboPerusahaan(ComboBox cbo) 
        {
            try   
            {
                DataTable dtPerusahaan = new DataTable();  
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                /*
                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                                dtPerusahaan.Columns.Add(cConcatenated);
                                dtPerusahaan.Rows.Add("");
                */
                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                dtPerusahaan.Rows.Add(Guid.Empty);


                    cbo.DataSource = dtPerusahaan;
                    cbo.DisplayMember = "Nama";
                    cbo.ValueMember = "RowID";
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerusahaan(ComboBox cbo, bool newDKN)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                /*
                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                                dtPerusahaan.Columns.Add(cConcatenated);
                                dtPerusahaan.Rows.Add("");
                */
                dt.DefaultView.RowFilter = "RowID='" + GlobalVar.PerusahaanRowID.ToString() + "'";
                dtPerusahaan = dt.DefaultView.ToTable().Copy();
                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                dtPerusahaan.Rows.Add(Guid.Empty);


                cbo.DataSource = dtPerusahaan;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void fillComboCabangNonCabangIDLogin(ComboBox cbo, bool newDKN)
        {
            DataTable dtCabang;
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    //if (PerusahaanRowID == Guid.Empty) 
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    //else
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST_FILTER_PT"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, PerusahaanRowID));
                    //}
                    //if (!string.IsNullOrEmpty(cabangID)) db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.RowFilter = "PerusahaanRowID='" + GlobalVar.PerusahaanRowID + "'";
                dtCabang = dt.DefaultView.ToTable().Copy();
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";
                for (int i = 0; i <= dtCabang.Rows.Count - 1; i++)
                {
                    if (dtCabang.Rows[i]["CabangID"].ToString() == GlobalVar.CabangID)
                    {
                        dtCabang.Rows[i].Delete();
                    }

                }
                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "CabangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerusahaanNonECR(ComboBox cbo)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                dtPerusahaan.Columns.Add(cConcatenated);
                //dtPerusahaan.Rows.Add(Guid.Empty);

                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                dtPerusahaan.Rows.Add(Guid.Empty);

                //for (int i = 0;i< dtPerusahaan.Rows.Count-1 ; i++)
                //{
                //    if (dtPerusahaan.Rows[i]["InitPerusahaan"].ToString()=="ECR")
                //    {
                //        dtPerusahaan.Rows[i].Delete();
                       
                //    }
                    cbo.DataSource = dtPerusahaan;
                    cbo.DisplayMember = "Concatenated";
                    cbo.ValueMember = "RowID";
                //}
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerusahaan(ComboBox cbo,Guid RowID)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                dtPerusahaan.Columns.Add(cConcatenated);
                //dtPerusahaan.Rows.Add("");

                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
               // dtPerusahaan.Rows.Add(Guid.Empty);


                cbo.DataSource = dtPerusahaan;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerusahaanNonPTCabangIDLokal(ComboBox cbo)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                dtPerusahaan.Columns.Add(cConcatenated);
                //dtPerusahaan.Rows.Add("");
                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                dtPerusahaan.Rows.Add(Guid.Empty);

                //for (int i = 0; i <= dtPerusahaan.Rows.Count - 1; i++)
                //{
                //    if (dtPerusahaan.Rows[i]["InitCabang"].ToString() ==GlobalVar.CabangID)
                //    {
                //        dtPerusahaan.Rows[i].Delete();

                //    }

                    cbo.DataSource = dtPerusahaan;
                    cbo.DisplayMember = "Nama";
                    cbo.ValueMember = "RowID";
                //}




            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerusahaanNoPerusahaanIDLocal(ComboBox cbo,int key)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                /*
                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                                dtPerusahaan.Columns.Add(cConcatenated);
                                dtPerusahaan.Rows.Add("");
                */
                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                dtPerusahaan.Rows.Add(Guid.Empty);

                for (int i = 0; i <= dtPerusahaan.Rows.Count - 1; i++)
                {
                    if (dtPerusahaan.Rows[i]["InitPerusahaan"].ToString() == GlobalVar.PerusahaanID)
                    {
                        dtPerusahaan.Rows[i].Delete();

                    }

                cbo.DataSource = dtPerusahaan;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboCabangPlustHO(ComboBox cbo)
        {
            DataTable dtCabang = DBTools.DBGetDataTable("usp_Cabang_LIST", new List<Parameter>());
            DataTable dtPerusahaan = DBTools.DBGetDataTable("usp_Perusahaan_LIST", new List<Parameter>());
            DataTable dt = new DataTable();
            dt.Columns.Add("CabangID", typeof(System.String));
            dt.Columns.Add("Nama", typeof(System.String));
            string cab;
            foreach (DataRow r in dtCabang.Rows)
            {
                cab = r["CabangID"].ToString();
                if (cab != GlobalVar.CabangID)
                {
                    DataRow dr = dt.Rows.Add();
                    dr["CabangID"] = r["CabangID"];
                    dr["Nama"] = r["CabangID"].ToString() + " | " + r["Nama"].ToString();
                }
            }

            foreach (DataRow r in dtPerusahaan.Rows)
            {
                cab = r["InitGudang"].ToString();
                if (!string.IsNullOrEmpty(cab))
                {
                    DataRow dr = dt.Rows.Add();
                    dr["CabangID"] = r["InitGudang"].ToString();
                    //dr["Nama"] = r["InitGudang"].ToString() + " | (" + r["InitPerusahaan"].ToString()+") Showroom - HO";
                    dr["Nama"] = r["InitGudang"].ToString() + " | Plur - " + r["InitPerusahaan"].ToString();
                }
            }
            dt.DefaultView.Sort = "CabangID ASC";
            cbo.DataSource = dt;
            cbo.DisplayMember = "Nama";
            cbo.ValueMember = "CabangID";
        }

        public void fillComboCabang(ComboBox cbo)
        {
            fillComboCabang(cbo, Guid.Empty, "");
        }

        public void fillComboCabang(ComboBox cbo, Guid PerusahaanRowID)
        {
            fillComboCabang(cbo, PerusahaanRowID, "");         
        }

        public void fillComboCabangNonCabangIDLocal(ComboBox cbo,  Guid PerusahaanRowID, string cabangID)
        {
            DataTable dtCabang; 
            try
            {
                using (Database db = new Database())
                {
                    if (PerusahaanRowID == Guid.Empty)
                        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST_FILTER_PT"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, PerusahaanRowID));
                    }
                    if (!string.IsNullOrEmpty(cabangID)) db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                } 

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";

                for (int i = 0; i <= dtCabang.Rows.Count - 1; i++)
                {
                    if (dtCabang.Rows[i]["CabangID"].ToString() == GlobalVar.CabangID)
                    {
                        dtCabang.Rows[i].Delete();
                    }
                    cbo.DataSource = dtCabang;
                    cbo.DisplayMember = "Concatenated";
                    cbo.ValueMember = "CabangID";
                }


                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboCabang(ComboBox cbo, Guid PerusahaanRowID, string cabangID)
        {
            DataTable dtCabang;
            try
            {
                using (Database db = new Database())
                {
                    if (PerusahaanRowID == Guid.Empty) db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST_FILTER_PT"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, PerusahaanRowID));
                    }
                    if (!string.IsNullOrEmpty(cabangID)) db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";

                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "CabangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboCabang(ComboBox cbo,string cabangID)
        {
            DataTable dtCabang;
            try
            {
                using (Database db = new Database())
                {
                     db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                     db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                     dtCabang = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);

                dtCabang.DefaultView.Sort = "CabangID ASC";

                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "CabangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboCabangNonCabangIDLogin(ComboBox cbo)
        {
            DataTable dtCabang;
            try
            {
                using (Database db = new Database())
                {
                    //if (PerusahaanRowID == Guid.Empty) 
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    //else
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST_FILTER_PT"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, PerusahaanRowID));
                    //}
                    //if (!string.IsNullOrEmpty(cabangID)) db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";
                for (int i = 0; i <= dtCabang.Rows.Count - 1; i++)
                {
                    if (dtCabang.Rows[i]["CabangID"].ToString() == GlobalVar.CabangID)
                    {
                        dtCabang.Rows[i].Delete();
                    }

                }
                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "CabangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboBank(ComboBox cbo)
        {
            fillComboBank(cbo, 1);
        }

        public void fillComboBank(ComboBox cbo, bool _isAktif)
        {
            fillComboBank(cbo, ((_isAktif)?1:0));
        }

        public void fillComboBank(ComboBox cbo, int nAktif) {
            try
            {
                DataTable dtBank = new DataTable();
                using (Database db = new Database())
                {
                    string sql = "";
                    sql = (nAktif == 0 || nAktif == 1) ? "usp_Bank_LIST_FILTER_Aktif" : "usp_Bank_LIST";
                    db.Commands.Add(db.CreateCommand(sql));
                    if (nAktif == 0 || nAktif == 1)
                        db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, (nAktif == 1) ));
                    dtBank = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "BankID + ' | ' + NamaBank");
                dtBank.Columns.Add(cConcatenated);
                dtBank.Rows.Add(Guid.Empty);
                dtBank.DefaultView.Sort = "BankID ASC";

                cbo.DataSource = dtBank;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboKas(ComboBox cbo)
        {
            try
            {
                DataTable dtKas = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kas_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dtKas = db.Commands[0].ExecuteDataTable();
                }
                dtKas.Rows.Add(Guid.Empty);
                dtKas.DefaultView.Sort = "Nama ASC";

                cbo.DataSource = dtKas;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboKas(ComboBox cbo,Guid PerusahaanRowID)
        {
            try
            {

               
                DataTable dtKas = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kas_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier,PerusahaanRowID));
                    dtKas = db.Commands[0].ExecuteDataTable();
                }
                dtKas.Rows.Add(Guid.Empty);
                dtKas.DefaultView.Sort = "Nama ASC";

                cbo.DataSource = dtKas;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
    
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboRekening(ComboBox cbo, Guid _bankRowID, bool filterPerusahaan)
        {
            Guid _perusahaanRowID = GlobalVar.PerusahaanRowID;
            bool lOk;
            if (filterPerusahaan) lOk = ((_perusahaanRowID != null) && (_perusahaanRowID != Guid.Empty)); else lOk = true;
            if (!string.IsNullOrEmpty(_bankRowID.ToString()))
            {
                try
                {
                    DataTable dtRekening = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekening_LIST_FILTER_BankID"));
                        db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, _bankRowID));
                        if (filterPerusahaan) db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _perusahaanRowID));
                        dtRekening = db.Commands[0].ExecuteDataTable();
                    }
                    DataColumn cConcatenatedR1 = new DataColumn("Concatenated", Type.GetType("System.String"), "NoRekening + ' | ' + NamaRekening");
                    dtRekening.Columns.Add(cConcatenatedR1);

                    dtRekening.Rows.Add((Guid)Guid.Empty);
                    dtRekening.DefaultView.Sort = "NoRekening ASC";

                    cbo.DataSource = dtRekening;
                    cbo.DisplayMember = "Concatenated";
                    cbo.ValueMember = "RowID";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        public void fillComboRekening(ComboBox cbo, Guid _bankRowID)
        {
            fillComboRekening(cbo, _bankRowID, false);
        }

        public void fillComboMataUang(ComboBox cbo)
        {
            try
            {
                DataTable dtMataUang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MataUang_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dtMataUang = db.Commands[0].ExecuteDataTable();
                }
                
                dtMataUang.DefaultView.Sort = "MataUangID ASC";
                dtMataUang.Rows.Add(System.DBNull.Value);

                cbo.DataSource = dtMataUang;
                cbo.DisplayMember = "MataUangID";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboVendor(ComboBox cbo)
        {
            DataTable dtVendor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    dtVendor = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "VendorID + ' | ' + NamaVendor");
                dtVendor.Columns.Add(cConcatenated);
                dtVendor.Rows.Add((Guid)Guid.Empty);
                dtVendor.DefaultView.Sort = "VendorID ASC";

                cbo.DataSource = dtVendor;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboVendor(ComboBox cbo,Guid RowID)
        {
            DataTable dtVendor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowiD", SqlDbType.UniqueIdentifier, RowID));
                    dtVendor = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "VendorID + ' | ' + NamaVendor");
                dtVendor.Columns.Add(cConcatenated);
              
                dtVendor.DefaultView.Sort = "VendorID ASC";

                cbo.DataSource = dtVendor;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboVendor2(ComboBox cbo)
        {
            DataTable dtVendor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST2"));
                    dtVendor = db.Commands[0].ExecuteDataTable();
                }

                dtVendor.DefaultView.Sort = "Nama ASC"; // "JnsTransaksi ASC"
                dtVendor.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtVendor;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboVendor2(ComboBox cbo, Guid RowID)
        {
            DataTable dtVendor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST2"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowiD", SqlDbType.UniqueIdentifier, RowID));
                    dtVendor = db.Commands[0].ExecuteDataTable();
                }

                dtVendor.DefaultView.Sort = "Nama ASC"; // "JnsTransaksi ASC"
                //dtVendor.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtVendor;
                cbo.DisplayMember = "Nama";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksi(ComboBox cbo)
        {
            fillComboJnsTransaksi(cbo, "A");
        }

        public void fillComboJnsTransaksi(ComboBox cbo, string arus) 
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST"));
//                    if ((arus=="I") || (arus=="O")) db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, arus));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksi(ComboBox cbo, Guid RowiD)
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST"));
                    //                    if ((arus=="I") || (arus=="O")) db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, arus));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowiD));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                //dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksi(ComboBox cbo, bool isNeedApproval)
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST_FILTER_Approval"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, isNeedApproval));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksiDIFFER_Pengeluaran(ComboBox cbo, bool isNeedApproval)
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST_DIFFERENCE_Pengeluaran"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, isNeedApproval));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksiDIFFER_Penerimaan(ComboBox cbo, bool isNeedApproval)
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST_DIFFERENCE_Penerimaan"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, isNeedApproval));

                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();

                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsTransaksiEQUAL(ComboBox cbo,bool IsNeedApprove)
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST_EQUAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, IsNeedApprove));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                dtJnsTransaksi.DefaultView.Sort = "namaTransaksi ASC"; // "JnsTransaksi ASC"
                dtJnsTransaksi.Rows.Add(System.DBNull.Value);
                cbo.DataSource = dtJnsTransaksi;
                cbo.DisplayMember = "NamaTransaksi";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboJnsKasBon(ComboBox cbo)
        {
            DataTable dt;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsKasBon_LIST"));
                     dt = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "JnsKasBon + ' | ' + Keterangan");
                dt.Columns.Add(cConcatenated);
                dt.Rows.Add(System.DBNull.Value);
                dt.DefaultView.Sort = "JnsKasBon ASC";

                cbo.DataSource = dt;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboPerkiraan(ComboBox cbo)
        {
            DataTable dtCabang;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST_FILTER_Pasif"));
                    db.Commands[0].Parameters.Add(new Parameter("@Pasif",SqlDbType.Bit,false));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "NoPerkiraan + ' | ' + NamaPerkiraan");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "NoPerkiraan ASC";

                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "NoPerkiraan";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboUser(ComboBox cbo)
        {
            DataTable dtCabang;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityUsers_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "UserID + ' | ' + UserName");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add("");
                dtCabang.DefaultView.Sort = "UserID ASC";

                cbo.DataSource = dtCabang;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboKelompokHI(ComboBox cbo)
        {
            DataTable dtKlpHI;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KelompokTransaksiHI_LIST"));
                    dtKlpHI = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "KodeKelompok + ' | ' + Keterangan");
                dtKlpHI.Columns.Add(cConcatenated);
                dtKlpHI.Rows.Add(Guid.Empty);
                dtKlpHI.DefaultView.Sort = "KodeKelompok ASC";

                cbo.DataSource = dtKlpHI;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        #region Fill combo karyawan

        public void FillComboKaryawan(ComboBox cbo,int flag,Guid RowID)
        {
            DataTable dtKaryawan;

            switch (flag)
            {
                case 0:
                    {
                        try
                        {
                            using (Database db = new Database())
                            {

                                db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                                dtKaryawan = db.Commands[0].ExecuteDataTable();

                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "KaryawanID + ' | ' + NamaKaryawan");
                                dtKaryawan.Rows.Add(Guid.Empty);
                                dtKaryawan.Columns.Add(cConcatenated);
                                dtKaryawan.DefaultView.Sort = "NamaKaryawan ASC";
                                cbo.DataSource = dtKaryawan;
                                cbo.DisplayMember = "Concatenated";
                                cbo.ValueMember = "RowID";
                            }
                        }
                        catch (Exception Ex) { Error.LogError(Ex); }
            
                        break;
                    }
                case 1:
                    {
                        try
                        {
                            using (Database db = new Database())
                            {

                                db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                                dtKaryawan = db.Commands[0].ExecuteDataTable();

                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "KaryawanID + ' | ' + NamaKaryawan");
                                //dtKaryawan.Rows.Add(Guid.Empty);
                                dtKaryawan.Columns.Add(cConcatenated);
                                dtKaryawan.DefaultView.Sort = "NamaKaryawan ASC";
                                cbo.DataSource = dtKaryawan;
                                cbo.DisplayMember = "Concatenated";
                                cbo.ValueMember = "RowID";
                            }
                        }
                        catch (Exception Ex) { Error.LogError(Ex); }
            
                        break;
                    }
            }            
            
           
        }

        #endregion

        #region Fill Combo Bagian

        public void fillComboBagian(ComboBox cbo)
        {
            DataTable dtBagian;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Bagian_LIST"));
                    dtBagian = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "NamaBagian");
                dtBagian.Columns.Add(cConcatenated);
                dtBagian.Rows.Add(Guid.Empty);
                dtBagian.DefaultView.Sort = "NamaBagian ASC";

                cbo.DataSource = dtBagian;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void fillComboBagianDanSub(ComboBox cbo)
        {
            DataTable dtBagian;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SubBagian_LIST"));
                    dtBagian = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "NamaBagian + ' | ' + NamaSubBagian");
                dtBagian.Columns.Add(cConcatenated);
                dtBagian.Rows.Add(Guid.Empty);
                dtBagian.DefaultView.Sort = "NamaBagian ASC";

                cbo.DataSource = dtBagian;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void fillComboKodeHILama(ComboBox cbo)
        {
            DataTable dtOldHI;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KelompokHIDBF_LIST"));
                    dtOldHI = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "KodeLama + ' | ' + Keterangan");
                dtOldHI.Columns.Add(cConcatenated);
                dtOldHI.Rows.Add(Guid.Empty);
                dtOldHI.DefaultView.Sort = "KodeLama ASC";

                cbo.DataSource = dtOldHI;
                cbo.DisplayMember = "Concatenated";
                cbo.ValueMember = "KodeLama";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        #endregion

    }
}
