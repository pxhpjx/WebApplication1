using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AAA aaa = new AAA();
            aaa.sss = "32532";
            aaa.ii = 123;
            var r = Copy(aaa);
        }


        T Copy<T>(T input) where T : class,new()
        {
            T Result = null;
            if (input != null)
            {
                Result = new T();
                Type type = typeof(T);
                PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo p in Props)
                {
                    object ElementValue = p.GetValue(input, null);
                    p.SetValue(Result, ElementValue, null);
                }
            }
            return Result;
        }
    }

    public class AAA
    {
        public string sss { get; set; }
        public int i { get; set; }
        public int ii { get; set; }
    }
}