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
            DateTime ddd = new DateTime(1392825600000);
            DateTime d1 = new DateTime(), d2 = new DateTime();
            if (d1 == d2)
                d1 = d2;
        }
    }
}