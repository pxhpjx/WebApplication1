using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class ip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];




            string url = getoutip();
        }


        string getoutip()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(@"http://pv.sohu.com/cityjson?ie=utf-8"));
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "rbq";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string s = sr.ReadToEnd();
            Regex r = new Regex("\\d+.\\d+.\\d+.\\d+");
            Match ma = r.Match(s);
            return ma.Value;
        }
    }
}


