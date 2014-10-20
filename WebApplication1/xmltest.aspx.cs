using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace WebApplication1
{
    public partial class xmltest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void write()
        {
            List<HostConfig4Storage> hcs = new List<HostConfig4Storage>();
            HostConfig4Storage hc = new HostConfig4Storage();
            hc.HostID = "123";
            hc.Host = ".baidu.com";
            hc.Referer = new string[] { "ref", "reffff", "reffffff" };
            hc.Timeout = 20;
            hc.UserAgent = new string[] { "ua", "uaaaa", "uaaaaaaaaa" };
            hc.MaxConnections = 3;
            hc.ErrorRegexs = new string[] { "ddddddddddd" };
            FakeCookie ck = new FakeCookie();
            ck.Name = "n";
            ck.Value = "v";
            hc.Cookies = new List<FakeCookie>();
            hc.Cookies.Add(ck);
            hc.Cookies.Add(ck);
            hc.Encoding = "UTF-8";
            hcs.Add(hc);
            //hcs.Add(hc);
            WriteSerXml(hcs);
        }

        protected void Write_Click(object sender, EventArgs e)
        {
            write();
            //Random R = new Random();
            //X x = new X();
            //x.Name = "NNsdgfs";
            //x.Value = "VCesgfesgfsd";
            //x.type = R.Next(1000);
            ////System.Xml.XmlDocument doc = new XmlDocument();
            ////Type type = typeof(X);
            ////object obj = Activator.CreateInstance(type);
            ////PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            ////foreach (PropertyInfo p in props)
            ////{
            ////    p.Name.Substring(0);
            ////    var v = p.GetValue(x, null);
            ////}
            ////Log.WriteXmlLog<X>(x);
            //WriteSerXml(x);
        }

        void WriteSerXml<T>(T item)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriter xw = XmlWriter.Create("C:\\xxx.xml");
            serializer.Serialize(xw, item);

        }
        T ReadSerXml<T>(string Path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlReader xr = XmlReader.Create(Path, null);
            T x = (T)serializer.Deserialize(xr);
            return x;
        }


        protected void Read_Click(object sender, EventArgs e)
        {
            X x = ReadSerXml<X>("C:\\xxx.xml");
            //serializer.Deserialize(
            //List<string> ls = Log.ReadXmlLog();
            //Repeater1.DataSource = ls;
            //Repeater1.DataBind();
            //Random R = new Random();
            //X x = new X();
            //x.Name = "NNsdgfs";
            //x.Value = "VCesgfesgfsd";
            //x.type = R.Next(1000);
            //ReadXmlLog("Name", "qqq");
        }

        public static X ReadXmlLog(string name, string value)
        {
            X item = new X();
            Type type = typeof(X);
            object obj = Activator.CreateInstance(type);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in props)
            {
                if (p.Name == name)
                    p.SetValue(item, value, null);
            }
            return item;
        }

    }

    [Serializable]
    public class X
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int type { get; set; }
    }

    [Serializable]
    public class HostConfig4Storage
    {
        public string HostID { get; set; }

        public string Host { get; set; }

        public string Encoding { get; set; }

        public int MaxConnections { get; set; }

        public string[] Referer { get; set; }

        public string[] UserAgent { get; set; }

        public List<FakeCookie> Cookies { get; set; }

        /// <summary>
        /// 超时秒数
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 被ban时包含的表达式
        /// </summary>
        public string[] ErrorRegexs { get; set; }

        /// <summary>
        /// 转化为配置项
        /// </summary>
        /// <returns></returns>
        public HostConfig ToHostConfig()
        {
            HostConfig hc = new HostConfig();
            hc.HostID = HostID;
            hc.Host = Host;
            hc.Encoding = Encoding;
            hc.MaxConnections = MaxConnections;
            hc.Referer = Referer;
            hc.UserAgent = UserAgent;
            hc.Timeout = Timeout;
            hc.ErrorRegexs = ErrorRegexs;
            if (Cookies != null && Cookies.Count > 0)
            {
                hc.Cookies = new List<Cookie>();
                foreach (FakeCookie fc in Cookies)
                {
                    Cookie c = new Cookie(fc.Name, fc.Value);
                    c.Expires = fc.Expires;
                    c.Domain = fc.Domain;
                    hc.Cookies.Add(c);
                }
            }
            return hc;
        }
    }

    [Serializable]
    public class FakeCookie
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public DateTime Expires { get; set; }

        public string Domain { get; set; }
    }

    [Serializable]
    public class HostConfig
    {
        public string HostID { get; set; }

        public string Host { get; set; }

        public string Encoding { get; set; }

        public int MaxConnections { get; set; }

        public string[] Referer { get; set; }

        public string[] UserAgent { get; set; }

        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// 超时秒数
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 被ban时包含的表达式
        /// </summary>
        public string[] ErrorRegexs { get; set; }
    }

}