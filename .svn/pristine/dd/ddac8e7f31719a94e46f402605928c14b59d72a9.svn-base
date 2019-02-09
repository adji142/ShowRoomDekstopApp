using System;
using System.Collections.Generic;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;
using System.Data;

namespace ISA.Showroom.Class
{
    public class FillComboBox
    {
        public static DataTable DBGetProvinsi(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetKota(Guid _rowID, Guid _provRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kota_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_provRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@ProvRowID", SqlDbType.UniqueIdentifier, _provRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetKecamatan(Guid _rowID, Guid _kotaRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kecamatan_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_kotaRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _kotaRowID));                    
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetKelurahan(Guid _rowID, Guid _kecRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kelurahan_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_kecRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetStateAll(Guid _provRowID, String _provinsi, Guid _kotaRowID, String _kota, 
            Guid _kecRowID, String _kecamatan, Guid _kelRowID, String _kelurahan)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                    if (_provRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _provRowID));
                    if (_kotaRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _kotaRowID));
                    if (_kecRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                    if (_kelRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KelRowID", SqlDbType.UniqueIdentifier, _kelRowID));
                    if (!string.IsNullOrEmpty(_provinsi)) db.Commands[0].Parameters.Add(new Parameter("@Provinsi", SqlDbType.VarChar, _provinsi));
                    if (!string.IsNullOrEmpty(_kota)) db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, _kota));
                    if (!string.IsNullOrEmpty(_kecamatan)) db.Commands[0].Parameters.Add(new Parameter("@Kecamatan", SqlDbType.VarChar, _kecamatan));
                    if (!string.IsNullOrEmpty(_kelurahan)) db.Commands[0].Parameters.Add(new Parameter("@Kelurahan", SqlDbType.VarChar, _kelurahan));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetArea(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetWilayah(Guid _rowID, Guid _areaRowID, Guid _kecRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Wilayah_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_areaRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    if (_kecRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetAreaKolektor(Guid _rowID, Guid _areaRowID, Guid _kolektorRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_Kolektor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_areaRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    if (_kolektorRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolektorRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetAreaSurveyor(Guid _rowID, Guid _areaRowID, Guid _surveyorRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_Kolektor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_areaRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    if (_surveyorRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, _surveyorRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetKolektor(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kolektor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetSurveyor(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Surveyor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetSales(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetVendor(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetMotor(Guid _merkRowID, Guid _typeRowID, String _merk, String _type)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Merk_LIST_ALL"));
                    if (_merkRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@MerkRowID", SqlDbType.UniqueIdentifier, _merkRowID));
                    if (_typeRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, _typeRowID));
                    if (!string.IsNullOrEmpty(_merk)) db.Commands[0].Parameters.Add(new Parameter("@Merk", SqlDbType.VarChar, _merk));
                    if (!string.IsNullOrEmpty(_type)) db.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, _type));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetTargetKolektor(Guid _rowID, Guid _kolektorRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TargetKolektor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_kolektorRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolektorRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetTargetSurveyor(Guid _rowID, Guid _surveyorRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TargetSurveyor_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_surveyorRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, _surveyorRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetTargetSales(Guid _rowID, Guid _salesRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TargetSales_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_salesRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, _salesRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetLeasing(Guid _rowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Leasing_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        // ubah dari custrowid  jadi type rowid
        public static DataTable DBGetPembelian(Guid _rowID, Guid _vendorRowID, Guid _typeRowID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (_vendorRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, _vendorRowID));
                    if (_typeRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, _typeRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetMataUang(Guid _rowID, string _matauangID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("usp_MataUang_LIST"));
                    if (_rowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    if (!string.IsNullOrEmpty(_matauangID)) db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, _matauangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        public static DataTable DBGetCabang(String _cabangID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    if (!string.IsNullOrEmpty(_cabangID)) db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier , GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }
    }
}
