using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DevLayer.Import
{
    class FTImp
    {
        #region 拼音

        /// <summary> 
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        /// </summary> 
        /// <param name="cnChar">单个汉字</param> 
        /// <returns>单个大写字母</returns> 
        public static string GetCharSpellCode(string cnChar)
        {
            if (cnChar == "选")
                return "X";

            if (cnChar == "鑫")
                return "X";

            long iCnChar;

            byte[] cnCharByte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(cnChar);

            if (cnCharByte.Length == 1)
            {
                if (cnCharByte[0] >= 'a' && cnCharByte[0] <= 'z')
                {
                    return cnChar.ToUpper();
                }
                else
                {
                    return cnChar;
                }
            }
            else
            {
                int i1 = (short)(cnCharByte[0]);
                int i2 = (short)(cnCharByte[1]);
                iCnChar = i1 * 256 + i2;
            }

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else
            {
                return (cnChar);
            }
        }

        /// <summary> 
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串 
        /// </summary> 
        /// <param name="input">汉字字符串</param> 
        /// <returns>相对应的汉语拼音首字母串</returns> 
        public static string GetSpellCode(string cnStr)
        {
            string strTemp = "";
            int iLen = cnStr.Length;
            int i = 0;

            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(cnStr.Substring(i, 1));
            }
            return strTemp;
        }

        #endregion


        #region 字符串处理

        /// <summary>
        /// 遮蔽字符串的后半段
        /// </summary>
        /// <param name="str"></param>
        /// <param name="IsEmail">是否邮箱。若是，不遮蔽@之后的内容。</param>
        /// <returns></returns>
        public static string StringMask(string str, bool IsEmail = false)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";
            else
            {
                string tail = "";
                if (IsEmail && str.IndexOf('@') > 0)
                {
                    tail = str.Substring(str.IndexOf('@'));
                    str = str.Substring(0, str.IndexOf('@'));
                }
                int L = str.Length;
                int l = L / 2;
                str = str.Substring(0, l);
                while (str.Length < L)
                    str += "*";
                return str + tail;
            }
        }

        public static string[] ReadColumns(string Source, int Cols)
        {
            string[] result = { "", "" };
            int i = 0, Cur = 0;
            Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
            while (Cur < Cols)
            {
                if (rx.IsMatch(Source[i].ToString()))
                    Cur += 2;
                else
                    Cur++;
                result[0] += Source[i];
                i++;
            }
            result[1] = Source.Substring(result[0].Length);
            result[0] = result[0].Trim();
            return result;
        }

        #endregion
    }
}
