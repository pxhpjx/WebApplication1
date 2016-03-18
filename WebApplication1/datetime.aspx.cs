using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class datetime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime det = (new DateTime(621355968000000000 + 1441683900000 * 10000)).AddHours(8);



            DateTime ddddd = new DateTime(2000, 1, 1);
            long t = ddddd.Ticks;
            DateTime dzzzzf = default(DateTime);


            DateTime dddd = DateTime.Parse("20150202");

            DateTime d = DateTime.Now.AddDays(-1);
            DateTime ds = d.Date.AddMonths(-1);
            DateTime de = d.Date.AddMinutes(-1);


            //DateTime d = DateTime.Parse("2014-11-18 16:03:29");




            //DateTime ddd = new DateTime(1392825600000);
            //DateTime d1 = new DateTime(), d2 = new DateTime();
            //if (d1 == d2)
            //    d1 = d2;
        }
    }
}