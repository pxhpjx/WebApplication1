using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class outref : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            A a1 = new A(1, "s");
            A a2 = new A(12, "s2");
            func1(ref a1);
        }


        void func1(ref A a)
        {
            a.i++;
        }
    }

    class A
    {
        public int i { get; set; }
        public string s { get; set; }
        public A(int ii, string ss)
        {
            i = ii;
            s = ss;
        }
    }

}