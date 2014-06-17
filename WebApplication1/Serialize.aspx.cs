using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace WebApplication1
{
    public partial class Serialize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<HttpConfig> list = new List<HttpConfig>();
            list.Add(new HttpConfig("1", "http://www.baidu.com"));
            list.Add(new HttpConfig("2", "http://www.baidu.com"));
            list.Add(new HttpConfig("3", "http://www.baidu.com"));

            LogRecord.WriteSerXmlLog<List<HttpConfig>>(list);


            List<HttpConfig> l2 = LogRecord.ReadSerXmlLog<List<HttpConfig>>(@"C:\Users\PangJiaxi\Documents\Visual Studio 2012\Projects\WebApplication1\WebApplication1\log\20131219141206373.xml");

            

            TextBox1.Text = "";
        }


        public class HttpConfig
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public HttpConfig()
            {
            }

            public HttpConfig(string s1, string s2)
            {
                Key = s1;
                Value = s2;
            }
        }


        public enum EEE
        {
            a = 1,
            b = 2,
            c = 3
        }
    }
}