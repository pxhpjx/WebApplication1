using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace WebApplication1
{
    public partial class Serialize : System.Web.UI.Page
    {
        class ArrayOfString : List<string>
        { }

        protected void Page_Load(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            string s = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><string>-7769793747618242454</string>";
            s = s.Replace(" xmlns=\"http://tempuri.org/\"", null);

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            var result = serializer.Deserialize(stream);


            string fp = "C:\\新建文本文档.txt";
            var v = LogRecord.ReadSerXmlLog<List<string>>(fp);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            //XmlReader xr = XmlReader.Create("http://61.145.229.28:7902/MWGate/wmgw.asmx/MongateCsSpSendSmsNew?userId=js0718&password=237888&pszMobis=15021068101&pszMsg=%E5%91%98%E5%B7%A5%E6%82%A8%E5%A5%BD%EF%BC%8C%E6%84%9F%E8%B0%A2%E6%82%A8%E5%AF%B9%E6%AD%A4%E6%AC%A1%E6%B5%8B%E8%AF%95%E7%9A%84%E9%85%8D%E5%90%88%E3%80%82&iMobiCount=1&pszSubPort=*");
            ////XmlReader xr = XmlReader.Create("<?xml version=\"1.0\" encoding=\"utf - 8\"?><string xmlns=\"http://tempuri.org/\">-7978591005732983869</string>");
            //var result = serializer.Deserialize(xr) as string;






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