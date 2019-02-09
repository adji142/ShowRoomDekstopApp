using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Pin;
using ISA.DAL;

namespace ISA.Showroom.Finance.Pin
{
    public partial class frmPin : Form
    {
        int _bagian, _modulId, _MingguKe, _periode;
        DateTime _tanggal;
        string _keterangan;
        Guid _srcrowID = Guid.Empty;

        // variabel untuk yg PrintLog
        bool _printLog = false;
        Guid _modulHeaderRowID = Guid.Empty;
        Guid _modulDetailRowID = Guid.Empty;
        String _headerTableName = "";
        String _detailTableName = "";

        // normal
        public frmPin(int periodePin, int bagian, int modulId, int MingguKe, DateTime tanggal, string keterangan)
        {
            this._bagian = bagian;
            this._modulId = modulId;
            this._MingguKe = MingguKe;
            this._keterangan = keterangan;
            this._tanggal = tanggal;
            this._periode = periodePin;
            InitializeComponent();
        }
        // untuk yg minta PIN Penjualan (tiap kali buka form buat Guid Baru)
        public frmPin(int periodePin, int bagian, int modulId, int MingguKe, DateTime tanggal, string keterangan, 
                      Guid srcRowID)
        {
            this._bagian = bagian;
            this._modulId = modulId;
            this._MingguKe = MingguKe;
            this._keterangan = keterangan;
            this._tanggal = tanggal;
            this._periode = periodePin;
            
            // -- tambahannya
            this._srcrowID = srcRowID;

            InitializeComponent();
        }
        // untuk kalau cetak -> PrintLog
        public frmPin(int periodePin, int bagian, int modulId, int MingguKe, DateTime tanggal, string keterangan, 
                      Guid modulHeaderRowID, Guid modulDetailRowID, String headerTableName, String detailTableName, bool printLog)
        {
            this._bagian = bagian;
            this._modulId = modulId;
            this._MingguKe = MingguKe;
            this._keterangan = keterangan;
            this._tanggal = tanggal;
            this._periode = periodePin;

            // -- tambahannya
            this._modulHeaderRowID = modulHeaderRowID; // kasih Guid.Empty kalau mau biar ngga ngirim parameter ini
            this._modulDetailRowID = modulDetailRowID; // kasih Guid.Empty kalau mau biar ngga ngirim parameter ini
            this._headerTableName = headerTableName; // kasih String.Empty kalau mau biar ngga ngirim parameter ini
            this._detailTableName = detailTableName; // kasih String.Empty kalau mau biar ngga ngirim parameter ini
            this._printLog = printLog; // mestinya selalu true (kalo ngga ngapain panggil overlaod yg ini -_-")

            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.ToString().Length != 8)
            {
                MessageBox.Show("Pin Yang anda masukan salah, silhakan Ulangi");
                txtPin.Text = "";
                return;
            }
            if (ISA.Pin.key.cek(txtKey.Text, txtPin.Text, _bagian))
            {
                GlobalVar.pinResult = true;
                if (_printLog == true && GlobalVar.pinResult == true)
                {
                    Database db = new Database();
                    int counterdb = 0;
                    try
                    {
                        // yang PINUnlockLog
                        db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, _modulId));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, _MingguKe));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, _tanggal));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, txtKey.Text));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PINEntered", SqlDbType.VarChar, txtPin.Text));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, _periode));

                        // di bagian print masukkin modulHeader/Detail RowID nya
                        if (_modulDetailRowID == Guid.Empty && _modulHeaderRowID == Guid.Empty)
                        {
                            // ngga perlu kasih parameter
                        }
                        // prioritas pertama yg jadi srcRowID itu modulDetailRowID
                        else if (_modulDetailRowID != Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _modulDetailRowID));
                        }
                        // baru modeulHeaderRowID yg jadi srcRowID
                        else if (_modulHeaderRowID != Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _modulHeaderRowID));
                        }


                        counterdb++;
                        
                        // yang PrintLog
                        db.Commands.Add(db.CreateCommand("usp_PrintLog_INSERT"));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)Guid.NewGuid()));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, _modulId));

                        if (_modulHeaderRowID == Guid.Empty) { }
                        else
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@ModulHeaderRowID", SqlDbType.UniqueIdentifier, _modulHeaderRowID));
                        }
                        if (_modulDetailRowID == Guid.Empty) { }
                        else
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@ModulDetailRowID", SqlDbType.UniqueIdentifier, _modulDetailRowID));
                        }
                        if(_headerTableName == String.Empty) {}
                        else 
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@HeaderTableName", SqlDbType.VarChar, _headerTableName));
                        }
                        if(_detailTableName == String.Empty) {}
                        else 
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@DetailTableName", SqlDbType.VarChar, _detailTableName));
                        }
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, txtKey.Text));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PINEntered", SqlDbType.VarChar, txtPin.Text));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PrintedDate", SqlDbType.DateTime, GlobalVar.GetServerDate));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PrintedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        counterdb++;

                        db.BeginTransaction();
                        int looper = 0;
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    catch(Exception ex)
                    {
                        db.RollbackTransaction();
                    }
                }
                else
                {
                    if (GlobalVar.pinResult)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                            db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, _modulId));
                            db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, _MingguKe));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, _tanggal));
                            db.Commands[0].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, txtKey.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PINEntered", SqlDbType.VarChar, txtPin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, _periode));
                            db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _srcrowID));
                            db.Commands[0].ExecuteDataTable();
                        }
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
        }

        private void frmPin_Load(object sender, EventArgs e)
        {
            string cabang = GlobalVar.CabangID;
            Random rnd = new Random();
            String angkaAcak = getOne(Convert.ToInt32(_tanggal.ToString("dd") + _tanggal.ToString("hh"))).ToString() + getOne(Convert.ToInt32(_tanggal.ToString("MM") + _tanggal.ToString("mm"))).ToString() + getOne(Convert.ToInt32(_tanggal.ToString("yyyy") + _tanggal.ToString("ss"))).ToString();
            txtKet.Text = this._keterangan;
            txtKet2.Text = this._keterangan;
            txtKet.Visible = false;
            string IDnya;
            if (this._modulId < 10) { IDnya = "0" + this._modulId.ToString(); } else { IDnya = this._modulId.ToString(); }
            txtKey.Text = cabang.Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E","") + IDnya + angkaAcak.ToString();
        }

        public static int getOne(int keyOri)
        {
            int xx;
            int keyNew = 0;
            if (keyOri.ToString().Length == 1)
            {
                return keyOri;
            }
            else
            {
                for (xx = 0; xx < keyOri.ToString().Length; xx++)
                {
                    keyNew = keyNew + Convert.ToInt32(keyOri.ToString().Substring(xx, 1));
                }
                return getOne(keyNew);
            }
        }
    }
}
