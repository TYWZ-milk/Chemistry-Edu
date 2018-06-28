using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    public class operation
    {
        public int mytoInt(string str)
        {
            return int.Parse(str);
        }

        public string mytoStr(int num)
        {
            return num.ToString();
        }

        public string toTwoStr(int num)
        {
            return Convert.ToString(num,2);
        }

        public string toSixteenStr(int num)
        {
            return Convert.ToString(num, 16);
        }

        public string toTenStr(int num)
        {
            return Convert.ToString(num, 10);
        }

        public string leftZero(int num)
        {
            return Convert.ToString(num, 16).PadLeft(2, '0');
        }

        public string replaceStr(string str, string placed, string placing)
        {
            return str.Replace(placed, placing);
        }

        public string cutStr(string str, string cutStr)
        {
            return str.Substring(str.IndexOf(cutStr) + 1);
        }

        public string splitStr_char(string str, char split)
        {
            string[] sptemp = str.Split(split);
            string temp = "";
            foreach (string var in sptemp)
            {
                temp += var;
            }
            return temp;
        }

        public string splitStr_word(string str, string split)
        {
            return str.Replace(str,split);
        }

        public string removeSpace(string str)
        {
            return str.Trim();
        }

        public char[] strToChar(string str)
        {
            return str.ToCharArray();
        }

        public string TestStringBytes(string s)
        {
            byte[] b1 = System.Text.Encoding.Default.GetBytes(s);

            string t1 = "";
            foreach (byte b in b1)
            {
                t1 += b.ToString("") + " ";
            }
            return t1.ToString();
        }

        public string byteToStr(byte[] bs)
        {
            return System.Text.Encoding.ASCII.GetString(bs);
        }

        public Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }

        public float strToFloat(string str)
        {
             return float.Parse(str);
        }

    }
}
