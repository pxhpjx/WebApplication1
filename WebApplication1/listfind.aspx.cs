using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class listfind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<cl> llll = new List<cl>();
            int sum = llll.Sum(item => item.i);



            List<DateTime> ld = new List<DateTime>();
            ld.Add(new DateTime(2012, 12, 12));
            ld.Add(new DateTime(2012, 11, 12));
            ld.Add(new DateTime(2012, 10, 12));
            ld.Add(new DateTime(2012, 12, 13));
            ld.Add(new DateTime(2012, 12, 14));
            ld.Add(new DateTime(2012, 12, 15));
            ld.Add(new DateTime(2012, 12, 16));

            DateTime d = ld.Find(item => item == new DateTime(2013, 12, 16));
            if (d == new DateTime())
            {
            }




            List<cl> l = new List<cl>();
            l.Add(new cl("123"));
            l.Add(new cl("w"));
            l.Add(new cl("e"));
            l.Add(new cl("ed"));
            l.Add(new cl("s"));
            l.Add(new cl("sdf"));
            l.Add(new cl("12aq3"));
            l.Add(new cl("1ad23"));
            cl c = l.Find(item => item.S == "ed");
            c.i = 123;

            List<cl> ll = l.FindAll(item => item.i == 999999);
        }
    }


    class cl
    {
        public string S;
        public int i;

        public cl(string sss)
        {
            S = sss;
            
        }
    }
}