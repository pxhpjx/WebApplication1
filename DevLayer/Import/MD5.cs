using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevLayer.Import
{
    public static class MD5
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ConvertString">原始字符串</param>
        /// <returns></returns>
        public static string GetMd5String(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            string strMD5 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)));

            strMD5 = strMD5.Replace("-", "").ToLower();

            return strMD5;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ConvertString">原始字符串</param>
        /// <param name="intType">16或者32</param>
        /// <returns></returns>
        public static string GetMd5String(string ConvertString, int intType)
        {
            string strMD5;
            if (intType == 16)
            {
                strMD5 = GetMd5String(ConvertString).Substring(8, 16);
            }
            else
            {
                strMD5 = GetMd5String(ConvertString);
            }
            return strMD5;
        }

    }
}
