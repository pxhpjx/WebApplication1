using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DevLayer.Dev
{
    public static class FTOth
    {
        /// <summary>
        /// 获取指定Url返回的数据流
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpResponseStream(string url)
        {
            string result = null;
            WebResponse webRes = null;
            try
            {
                WebRequest webReq = WebRequest.Create(url);
                webRes = webReq.GetResponse();
                Stream resStream = webRes.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
                string str = "", line;
                while ((line = sr.ReadLine()) != null)
                {
                    str += line;
                }
                result = str;
            }
            catch { }
            if (webRes != null)
                webRes.Close();

            return result;
        }


        /// <summary>
        /// 生成浮动范围内的随机数
        /// </summary>
        /// <param name="BaseRate"></param>
        /// <param name="FloatRate"></param>
        /// <returns></returns>
        public static int RandomFloat(int BaseRate = 100, int FloatRate = 10, int LowerLimit = 0)
        {
            Random R = new Random();
            int Result = (BaseRate - FloatRate + R.Next(FloatRate * 2 + 1));
            if (Result < LowerLimit)
                Result = LowerLimit;
            return Result;
        }

        public static int RandomBetween(int LowerLimit, int UpperLimit)
        {
            Random R = new Random();
            return LowerLimit + R.Next(UpperLimit - LowerLimit + 1); ;
        }

    }
}
