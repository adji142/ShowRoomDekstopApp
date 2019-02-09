
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using ISA.Pin;
using System.Windows.Forms;

namespace ISA.Pin
{
    public class key
    {
        

        public struct Bagian
        {
             public const int C0101 =1;
             public const int C0901 =2;
             public const int C0902 =3;
             public const int C0903 =4;
             public const int C0905 =5;
             public const int C1801 =6;
             public const int C1901 =7;
             public const int C2001 =8;
             public const int C2101 =9;
             public const int C2201 =10;
             public const int C2501 =11;
        }

        public static Boolean cek(string _key, string _pin, int _id)
        {
            string kunci, pin;
            int i, key1, key2, key3, key0,key4,key5,key6, keyJml;
            Boolean status = true;
            string keyCek;
            keyJml = 0;
            kunci = _key;

            for (i = 0; i < 7; i++)
            {
                keyJml = keyJml + Convert.ToInt32(_key.Substring(i, 1));
            }
            pin = _pin.Substring(0, 1) + _pin.Substring(2, 1) + _pin.Substring(6, 1) + _pin.Substring(7, 1);

            key0 = Convert.ToInt32(kunci.Substring(0, 1)) + Convert.ToInt32(kunci.Substring(1, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key1 = Convert.ToInt32(kunci.Substring(1, 1)) + Convert.ToInt32(kunci.Substring(2, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key2 = Convert.ToInt32(kunci.Substring(2, 1)) + Convert.ToInt32(kunci.Substring(3, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key3 = Convert.ToInt32(kunci.Substring(3, 1)) + Convert.ToInt32(kunci.Substring(4, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key4 = Convert.ToInt32(kunci.Substring(4, 1)) + Convert.ToInt32(kunci.Substring(5, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key5 = Convert.ToInt32(kunci.Substring(5, 1)) + Convert.ToInt32(kunci.Substring(6, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key6 = Convert.ToInt32(kunci.Substring(6, 1)) + Convert.ToInt32(kunci.Substring(0, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
           
            key0 = getOne(key0 + Convert.ToInt32(kunci.Substring(0, 2)));
            key1 = getOne(key1 + Convert.ToInt32(kunci.Substring(0, 2)));
            key2 = getOne(key2 + Convert.ToInt32(kunci.Substring(0, 2)));
            key3 = getOne(key3 + Convert.ToInt32(kunci.Substring(0, 2)));
            key4 = getOne(key4 + Convert.ToInt32(kunci.Substring(0, 2)));
            key5 = getOne(key5 + Convert.ToInt32(kunci.Substring(0, 2)));
            key6 = getOne(key6 + Convert.ToInt32(kunci.Substring(0, 2)));

            key0 = getOne(key0 + key6);
            key1 = getOne(key1 + key5);
            key2 = getOne(key2 + key4);
            key3 = getOne(key3);

            keyCek = key0.ToString() + key1.ToString() + key2.ToString() + key3.ToString();

            if (_pin.Length != 8) { status = false; }
            if (keyCek != pin) { status = false; } 

            int jam = Convert.ToInt32(_pin.Substring(4, 1) + _pin.Substring(1, 1)) - key4 - key5 - key6 - _id;
            int menit = Convert.ToInt32(_pin.Substring(3, 1) + _pin.Substring(5, 1)) - key4 - key5 - key6 - _id;
          
            if (jam > 24 && jam < 0) { return false; } 
            if (menit > 60 || menit < 0) { return false; }

            string dateTimeStr = jam.ToString() + ":" + menit.ToString(); 
            DateTime waktuPin = DateTime.Parse(dateTimeStr);
            DateTime waktuSekarang = DateTime.Now;
            if (waktuSekarang > waktuPin) { status = false; } 
            return status; 
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


        public static string proses(string _key, int _id, string cabang)
        {
            

            string key, jamString, menitString;
            int i, key1, key2, key3, key0, key4, key5, key6, keyJml;

            keyJml = 0;
            key = _key;
            for (i = 0; i < 7; i++)
            {
                keyJml = keyJml + Convert.ToInt32(key.Substring(i, 1));

            }
            key0 = Convert.ToInt32(key.Substring(0, 1)) + Convert.ToInt32(key.Substring(1, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key1 = Convert.ToInt32(key.Substring(1, 1)) + Convert.ToInt32(key.Substring(2, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key2 = Convert.ToInt32(key.Substring(2, 1)) + Convert.ToInt32(key.Substring(3, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key3 = Convert.ToInt32(key.Substring(3, 1)) + Convert.ToInt32(key.Substring(4, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key4 = Convert.ToInt32(key.Substring(4, 1)) + Convert.ToInt32(key.Substring(5, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key5 = Convert.ToInt32(key.Substring(5, 1)) + Convert.ToInt32(key.Substring(6, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key6 = Convert.ToInt32(key.Substring(6, 1)) + Convert.ToInt32(key.Substring(0, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key0 = getOne(key0 + Convert.ToInt32(cabang));
            key1 = getOne(key1 + Convert.ToInt32(cabang));
            key2 = getOne(key2 + Convert.ToInt32(cabang));
            key3 = getOne(key3 + Convert.ToInt32(cabang));
            key4 = getOne(key4 + Convert.ToInt32(cabang));
            key5 = getOne(key5 + Convert.ToInt32(cabang));
            key6 = getOne(key6 + Convert.ToInt32(cabang));

            key0 = getOne(key0 + key6);
            key1 = getOne(key1 + key5);
            key2 = getOne(key2 + key4);
            key3 = getOne(key3);
            
            int jam = Convert.ToInt32(DateTime.Now.AddHours(4).ToString("HH")) +  key4 + key5 + key6 + _id;
            int menit = Convert.ToInt32(DateTime.Now.AddHours(4).ToString("mm")) + key4 + key5 + key6 + _id;

            if (Convert.ToString(jam).Length == 1) { jamString = "0" + jam.ToString(); } else { jamString = jam.ToString(); }
            if (Convert.ToString(menit).Length == 1) { menitString = "0" + menit.ToString(); } else { menitString = menit.ToString(); }

            string pin = key0.ToString()
                        + jamString.Substring(1, 1)
                        + key1.ToString()
                        + menitString.Substring(0, 1)
                        + jamString.Substring(0, 1)
                        + menitString.Substring(1, 1)
                        + key2.ToString()
                        + key3.ToString();
           
            return pin;
        }      
    }
}
