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

namespace WebApplication1
{
    public partial class xmltest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Write_Click(object sender, EventArgs e)
        {
            Random R = new Random();
            X x = new X();
            x.Name = "NNsdgfs";
            x.Value = "VCesgfesgfsd";
            x.type = R.Next(1000);
            //System.Xml.XmlDocument doc = new XmlDocument();
            //Type type = typeof(X);
            //object obj = Activator.CreateInstance(type);
            //PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo p in props)
            //{
            //    p.Name.Substring(0);
            //    var v = p.GetValue(x, null);
            //}
            //Log.WriteXmlLog<X>(x);
            WriteSerXml(x);
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


}