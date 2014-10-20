using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class CompareInt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stopwatch sw1 = new Stopwatch(), sw2 = new Stopwatch();
            int cmp = 0, i = 0;
            sw1.Start();
            while (i < 1000000000)
            {
                if (cmp <= 0)
                    i++;
            }
            sw1.Stop();
            i = 0;
            sw2.Start();
            while (i < 1000000000)
            {
                if (cmp == 0)
                    i++;
            }
            sw2.Stop();
            Response.Write(sw1.ElapsedMilliseconds + "<br />" + sw2.ElapsedMilliseconds);
        }
    }
}