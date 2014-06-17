using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace WebApplication1
{
    public partial class continualGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpRuntime.Cache.Insert("ppp", "Empty");
            Random r = new Random();
            int l = 5000 + r.Next(1000);
            for (int i = 0; i < l; i++)
            {
                System.Threading.Thread.Sleep(r.Next(200));
                //if (i % 10 == 0)
                HttpRuntime.Cache.Insert("ppp", Math.Round(100.0 * i / l, 2).ToString() + "%(" + i.ToString() + "/" + l.ToString() + ")");
                HttpRuntime.Cache.Insert("pppp", (int)(1000.0 * i / l));

            }
            HttpRuntime.Cache.Insert("ppp", "完成！");
        }

        public struct r
        {
            public string a;
            public int b;
        }

        [WebMethod]
        public static r Get()
        {
            object obj = HttpRuntime.Cache.Get("ppp");
            object obj2 = HttpRuntime.Cache.Get("pppp");
            r rr = new r();
            if (obj != null && obj2 != null)
            {
                rr.a = obj.ToString();
                rr.b = int.Parse(obj2.ToString());
            }

            return rr;

        }
    }
}