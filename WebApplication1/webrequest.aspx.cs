using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class webrequest : System.Web.UI.Page
    {
        public static CookieContainer cc = new CookieContainer();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string ip = GetIP();

            //return;

            string url = "http://m.dianping.com/shop/13371054/more_info";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest.Method = "GET";
            webRequest.ContentType = "text/html";
            webRequest.UserAgent = "rbq";
            webRequest.CookieContainer = cc;
            //webRequest.Timeout = 1;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string h = response.Headers["Set-Cookie"];
            cc.SetCookies(new Uri(url), h);
            //cc = SplitSetCookies(h, url.Substring(7, url.IndexOf('/', 8) - 7));
            Stream sm = response.GetResponseStream();


            byte[] bytes;// = new byte[response.ContentLength];
            //sm.Read(bytes, 0, bytes.Length);
            int b;
            List<byte> bl = new List<byte>();
            do
            {
                b = sm.ReadByte();
                bl.Add((byte)b);
            }
            while (b != -1);
            bytes = bl.ToArray();
            //// 设置当前流的位置为流的开始
            ////sm.Seek(0, SeekOrigin.Begin);


            ////StreamReader sr = new StreamReader(sm, Encoding.UTF8);
            ////string s = sr.ReadToEnd();

            ////byte[] array = Encoding.UTF8.GetBytes(s);
            ////Stream stream = new MemoryStream(array);
            System.Drawing.Image bm = System.Drawing.Image.FromStream(new MemoryStream(bytes));
            bm.Save("c:/1.jpg");
            Bitmap nb = new Bitmap(bm.Width / 2, bm.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(bm, 0, -45, bm.Width, bm.Height);
            nb.Save("c:/2.jpg");
            bm.Save("c:/3.jpg");
            ////Response.Write(s);
        }

        public static string GetIP()
        {
            string result = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(@"http://pv.sohu.com/cityjson?ie=utf-8"));
                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.UserAgent = "WCF";
                webRequest.Timeout = 3000;
                response = (HttpWebResponse)webRequest.GetResponse();
                sr = new StreamReader(response.GetResponseStream());
                result = new Regex("\\d+.\\d+.\\d+.\\d+").Match(sr.ReadToEnd()).Value;
            }
            catch { }
            if (response != null)
                response.Close();
            if (sr != null)
                sr.Dispose();
            return result;
        }




        CookieContainer SplitSetCookies(string str, string defaultDomain)
        {
            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(defaultDomain))
                return null;
            string[] ss = str.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ss == null || ss.Length == 0)
                return null;
            CookieContainer result = new CookieContainer();
            Cookie c = null;
            foreach (string s in ss)
            {
                string ts = s.Trim();
                if (ts.ToLower().Contains("path"))
                {
                    c.Path = ts.Substring(ts.IndexOf('=') + 1);
                    continue;
                }
                if (ts.ToLower().Contains("domain"))
                {
                    c.Domain = ts.Substring(ts.IndexOf('=') + 1);
                    continue;
                }
                if (ts.ToLower().Contains("gmt"))
                {
                    c.Expires = FormatTools.ParseDate(ts.Substring(ts.IndexOf('=') + 1));
                    continue;
                }
                if (c != null)
                {
                    if (string.IsNullOrWhiteSpace(c.Domain))
                        c.Domain = defaultDomain;
                    result.Add(c);
                }
                c = new Cookie(ts.Substring(0, ts.IndexOf('=')), ts.Substring(ts.IndexOf('=') + 1));
            }
            return result;
        }
    }
}