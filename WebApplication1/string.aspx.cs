using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _string : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sss = "0001一楼      营业    张三      2015-08-20 00:00:00.000   ";
            string rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 4);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 10);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 8);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 10);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 100);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 100);
            rrrrrr = CutOutStringByByte(ref sss, Encoding.GetEncoding("GB2312"), 100);

            //int i = 0;
            //string ssssss = CutOutString(ref sss, 2);
            string ns = null;
            byte[] bs = Encoding.GetEncoding("GB2312").GetBytes(string.Empty);
            bs = Encoding.GetEncoding("GB2312").GetBytes("cx啊");
            bs = Encoding.ASCII.GetBytes(new char[] { 'c' });
            string s = string.Format("{1}{2}{3}", "q", "w", "e", "r", "t");
        }


        public static string CutOutString(ref string input, int cutLen, int cutStart = 0, bool allowOverstep = false)
        {
            if (string.IsNullOrWhiteSpace(input) || cutLen <= 0 || cutStart < 0 || cutStart > input.Length)
                return null;

            string result = null;
            if (input.Length < cutLen + cutStart)
            {
                if (!allowOverstep)
                    return result;
                result = input.Substring(cutStart);
                input = input.Remove(cutStart);
                return result;
            }
            result = input.Substring(cutStart, cutLen);
            input = input.Remove(cutStart, cutLen);
            return result;
        }

        public static string CutOutStringByByte(ref string input, Encoding encoding, int cutLen, int cutStart = 0)
        {
            if (string.IsNullOrWhiteSpace(input) || cutLen <= 0 || cutStart < 0)
                return null;

            string result = string.Empty, ir = input;
            int cur = 0, esp = 0;
            while (cur < input.Length)
            {
                char cc = input[cur];
                byte[] bs = encoding.GetBytes(new char[] { cc });
                if (encoding.GetBytes(result).Length + bs.Length > cutLen)
                    return null;
                if (esp >= cutStart)
                    result += input[cur];
                if (encoding.GetBytes(result).Length == cutLen)
                {
                    input = input.Remove(input.IndexOf(result), result.Length);
                    return result;
                }
                esp += bs.Length;
                cur++;
            }
            return null;
        }
    }
}