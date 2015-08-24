using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class attr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Assembly ass = Assembly.LoadFrom(@"G:\OneDrive\Projects\WebApplication1\ExtDll\bin\Debug\ExtDll.dll");

            Type et = ass.GetType("ExtDll.ClassExt");

            MethodInfo[] ms = et.GetMethods();

            foreach (var m in ms)
            {
                int? i;
                if (m.IsStatic)
                    i = m.Invoke(null, null) as int?;
                else
                    i = m.Invoke(Activator.CreateInstance(et), null) as int?;
            }




            return;

            MethodInfo[] methods = typeof(tc).GetMethods();
            foreach (var m in methods)
            {
                int? i = m.Invoke(null, null) as int?;
                var a = m.GetCustomAttributes(typeof(Attr), true) as Attr[];
                if (a.Length > 0)
                {
                    string s = a[0].CCCC();
                }
            }
        }

    }

    public static class tc
    {
        [Attr]
        public static int zz()
        {
            return 1;
        }

        [Attr]
        public static int zzz()
        {
            return 1;
        }

        public static int zzzz()
        {
            return 1;
        }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class Attr : Attribute
    {
        public string CCCC()
        {
            return "sss";
        }
    }
}