using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AAA a1 = new AAA();
            //AAA a2 = FormatTools.SampleCopy(a1);
            //AAA a3 = default(AAA);
            //Type t = a1.GetType();
            //if (t.IsClass)
            //{

            //}

            //a1.b = new BBB();
            //a1.b.i = 1;
            //a2 = FormatTools.SampleCopy(a1);
            //a3 = FormatTools.ValueCopy(a1);
            //a1.b.i = 12;

            //BBB b2 = FormatTools.ValueCopy(a1.b);
            //var l = a1.GetType().GetProperties();
            //string cn = t.Namespace + t.Name + t.FullName + t.DeclaringType.Name + t.DeclaringType.FullName + t.DeclaringType.Namespace;
            ////var dm = t.DeclaringMethod;
            //var aa = Activator.CreateInstance(a1.GetType());

            //List<AAA> la = new List<AAA>();
            AAA a1 = new AAA();
            //AAA a2 = new AAA();
            //AAA a3 = new AAA();
            a1.b = new BBB();
            a1.b.i = 22;
            a1.s = "ggg";
            a1.oo();
            //a2.b = new BBB();
            //a3.s = "sss";
            //la.Add(a1);
            //la.Add(a2);
            //la.Add(a3);
            //List<AAA> lac = FormatTools.ValueCopy(la);
            //AAA a1c = FormatTools.ValueCopy(a1);
            AAA aa = FormatTools.ValueCopy(a1);
            St st1 = new St();
            St st2 = st1;
            st1.i = 123;
            st1.s = "qqq";
            St st3 = FormatTools.ValueCopy(st1);




            List<int> li = new List<int>();
            Type lit = li.GetType();
            bool idarr = lit.IsArray;
        }




        struct St
        {
            public int i;
            public string s;
        }



        class AAA
        {
            public string s { get; set; }
            public BBB b { get; set; }

            private int pi { get; set; }

            public void oo()
            {
                pi = 123;
            }
        }

        class BBB
        {
            public int i { get; set; }
        }
    }
}